using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using RestSharp;
using TTU_CORE_ADMISSION_PORTAL_REACTJS.Data;
using TTU_CORE_ADMISSION_PORTAL_REACTJS.Models;
using TTU_CORE_ADMISSION_PORTAL_REACTJS.Services;
using TTU_CORE_ASP_ADMISSION_PORTAL.Services;

namespace TTU_CORE_ADMISSION_PORTAL_REACTJS.Controllers;

[EnableCors("AdmissionCORS")]
[Authorize]
[ApiController]
[Route("[controller]")]
public class ApplicationFormController : ControllerBase
{
    private readonly ILogger<ApplicationFormController> _logger;

    private readonly ApplicationDbContext _dbContext;
    readonly RestClient _client;
    private readonly IHelper _helper;
    private readonly UserManager<ApplicationUser> _userManager;

    public ApplicationFormController(ILogger<ApplicationFormController> logger, IHelper helper,
        UserManager<ApplicationUser> userManager,
        ApplicationDbContext dbContext)
    {
        _logger = logger;
        _userManager = userManager;
        _dbContext = dbContext;
        _helper = helper;
    }

    [HttpGet]
    [Produces("application/json")]
    public async Task<IActionResult> IndexAsync()
    {
        _logger.LogInformation("User visited dashboard.");
        var _formService = new FormService(_dbContext);
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var formData = _dbContext.Users.FirstOrDefault(a => a.Id == userId);
        var applicationNo = formData?.FormNo;
        var status = formData?.Admitted;
        if (applicationNo == null)
        {
            var Year = (DateTime.Now.Year).ToString();
            var application = _formService.GetFormNo();
            formData.FormNo = Year + application;

            if (await _dbContext.SaveChangesAsync() == 1)
            {
                // if we are able to allocate form number to an applicant
                // then lets update the form number generator + 1
                await _formService.UpdateFormNoAsync();
            }
        }
        else
        {
            
            return Ok(new {
                formNo=applicationNo,
                pictureUploaded=formData.PictureUploaded,
                formCompleted=formData.FormCompleted,
                admisionStatus=formData.Admitted
                
            }
            );
        }

        if ((bool)status)
        {
            var applicantModel =
                await _dbContext.ApplicantModel.FirstOrDefaultAsync(a => a.ApplicationUserId == userId);
            var applicantNo = applicantModel.ApplicationNumber;
            Console.WriteLine(" room is " + applicantModel.RoomNo);
            var programmeadmittedid = _helper.GetApplicantCodeFromId((int)applicantModel.ProgrammeAdmittedId);
            var leveladmitted = applicantModel.leveladmitted;
            var yearofadmission = applicantModel.YearOfAdmission;
            var hallfees = _helper.GetHallFee(applicantModel.HallAdmitted);
            var hallname = _helper.GetHallName(applicantModel.HallAdmitted);
            // calling external api .. srms


            var clientFeeComponents =
                new RestRequest(
                        $"https://srms.ttuportal.com/api/fees/components/{programmeadmittedid}/program/{leveladmitted}/level/{yearofadmission}/year/{applicantModel.AdmissionType}/type")
                    .AddJsonBody(new
                    {
                        year = yearofadmission,
                        type = "School Fees",
                        applicationNumber = applicantNo
                    });
            var responseClientFeeComponents = await _client.GetAsync(clientFeeComponents);


            Console.WriteLine(
                $"https://srms.ttuportal.com/api/fees/components/{programmeadmittedid}/program/{leveladmitted}/level/{yearofadmission}/year");
            // fetch hall fee and school fees paid from srms and update admissions accordingly
            var requestSRMSAUF =
                new RestRequest($"https://srms.ttuportal.com/api/applicant/fees/fetch").AddJsonBody(new
                {
                    year = yearofadmission,
                    type = "School Fees",
                    applicationNumber = applicantNo
                });
            var responseSRMS = await _client.PostAsync(requestSRMSAUF);
            double schoolFeesPaid = Convert.ToDouble(responseSRMS.Content);

            var requestSRMSHall =
                new RestRequest($"https://srms.ttuportal.com/api/applicant/fees/fetch").AddJsonBody(new
                {
                    year = yearofadmission,
                    type = "Hostel Fees",
                    applicationNumber = applicantNo
                });
            var responseSRMSHall = await _client.PostAsync(requestSRMSHall);
            double hallFeesPaid = Convert.ToDouble(responseSRMSHall.Content);

            var applicantData =
                await _dbContext.ApplicantModel.FirstOrDefaultAsync(a => a.ApplicationUserId == userId);
            Console.WriteLine("school fees" + schoolFeesPaid);

            var FeesPaids = 0.0;
            var HallFeesPaids = 0.0;

            FeesPaids = schoolFeesPaid;

            HallFeesPaids = hallFeesPaid;

            applicantData.FeesPaid = Convert.ToDecimal(FeesPaids);
            applicantData.HallFeesPaid = Convert.ToDecimal(HallFeesPaids);
            await _dbContext.SaveChangesAsync();


            return Ok(new
            {
                formNo=applicationNo,
                pictureUploaded=formData.PictureUploaded,
                formCompleted=formData.FormCompleted,
                admisionStatus=formData.Admitted,
                fees = FeesPaids, type = applicantData.AdmissionType, hall = hallname,
                feedata = responseClientFeeComponents.Content,
                hallfee = hallfees,
                hallfeespaid = applicantModel.HallFeesPaid,
                resident = applicantModel.ResidentialStatus,
                room = applicantModel.RoomNo
            });
        }

        return Ok();
    }

    [Route("/finalize")]
    public async Task<IActionResult> FinanlizedAsync()
    {
        _logger.LogInformation("User finalized forms.");

        var _formService = new FormService(_dbContext);

        var ApplicantId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId

        var applicant = await _dbContext.Users.FindAsync(ApplicantId);

        applicant.FormCompleted = 1;
        applicant.Finalized = 1;

        await _dbContext.SaveChangesAsync();

        // pull applicant info from applicant table

        var applicantModel =
            await _dbContext.ApplicantModel.FirstOrDefaultAsync(a => a.ApplicationUserId == ApplicantId);
        var phone = applicantModel.Phone;

        var fname = applicantModel.FirstName;
        var pin = applicantModel.ApplicationUser.Pin;
        var serial = applicantModel.ApplicationUser.UserName;

        var message = "Hi " + fname + " your application has been received. Vist admissions.ttuportal.com with " +
                      serial + " as serial and " + pin + " as pin to check your admission status";


        var result = _helper.SendSMSNotification(phone, message);


        //Console.WriteLine("ddd");


        return Ok();

        // return RedirectToAction("Index", "Home");
    }
}