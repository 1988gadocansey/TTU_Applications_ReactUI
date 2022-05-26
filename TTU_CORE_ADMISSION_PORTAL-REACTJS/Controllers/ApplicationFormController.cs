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

namespace TTU_CORE_ADMISSION_PORTAL_REACTJS.Controllers;

//[EnableCors("AdmissionCORS")]
//[Authorize]
[ApiController]
[Route("[controller]")]
public class ApplicationFormController : ControllerBase
{
    private readonly ILogger<ApplicationFormController> _logger;

    private readonly ApplicationDbContext _dbContext;
    readonly RestClient _client;
    private readonly IHelper _helper;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IHttpContextAccessor _httpContextAccessor;

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
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var formData = _dbContext.Users.FirstOrDefault(a => a.Id == userId);
        var applicationNo = formData?.FormNo;
        var status = formData?.Admitted;
        if (applicationNo == null)
        {
            //var Year = (DateTime.Now.Year).ToString();
            var FormGenerator = _dbContext.FormNoModel.OrderByDescending(form => form.Id).FirstOrDefault();
            var application = _helper.GetFormNo();
            formData.FormNo = FormGenerator.Year + application;
            if (await _dbContext.SaveChangesAsync() == 1)
            {
                // if we are able to allocate form number to an applicant
                // then lets update the form number generator + 1
                await _helper.UpdateFormNo();
            }
        }
        else
        {
            return Ok(new
                {
                    formNo = applicationNo,
                    pictureUploaded = formData.PictureUploaded,
                    formCompleted = formData.FormCompleted,
                    admisionStatus = formData.Admitted
                }
            );
        }

        if (!(bool)status) return Ok();
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
                formNo = applicationNo,
                pictureUploaded = formData.PictureUploaded,
                formCompleted = formData.FormCompleted,
                admisionStatus = formData.Admitted,
                fees = FeesPaids, type = applicantData.AdmissionType, hall = hallname,
                feedata = responseClientFeeComponents.Content,
                hallfee = hallfees,
                hallfeespaid = applicantModel.HallFeesPaid,
                resident = applicantModel.ResidentialStatus,
                room = applicantModel.RoomNo
            });
        }
    }

    [HttpPost("SaveForm")]
    // [ValidateAntiForgeryToken]
    /*[FromQuery] - Gets values from the query string.
    [FromRoute] - Gets values from route data.
    [FromForm] - Gets values from posted form fields.
    [FromBody] - Gets values from the request body.
    [FromHeader] - Gets values from HTTP headers.*/
    public async Task<IActionResult> SaveForm( [FromBody] ApplicantModel applicantForm)
    {
        Console.Write("hello");
        _logger.LogInformation("hello from form " + HttpContext.Request.Form["LastName"]);
        Console.WriteLine("Last name is " + HttpContext.Request.Form["LastName"]);

        var ConfigurationData = _helper.GetConfiguration();

        Console.Write("hello from form controller");
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var formData = _dbContext.Users.FirstOrDefault(a => a.Id == userId);
        var ApplicantForm = formData?.FormNo;
        var userFormType = formData?.Type;
        /* string dob = HttpContext.Request.Form["dob"];
 
         var dobArray = dob.Split("-");
 
         var dateOfBirth = new DateTime(Convert.ToInt32(dobArray[0]), Convert.ToInt32(dobArray[1]),
             Convert.ToInt32(dobArray[2]), 7, 0, 0);
         var region =
             await _dbContext.RegionModel.FirstOrDefaultAsync(r =>
                 r.Id == Convert.ToInt32(HttpContext.Request.Form["region"]));
 
         var district =
             await _dbContext.DistrictModel.FirstOrDefaultAsync(d =>
                 d.ID == Convert.ToInt32(HttpContext.Request.Form["district"]));
 
         var firstChoice = await _dbContext.ProgrammeModel.FirstOrDefaultAsync(p =>
             p.Id == Convert.ToInt32(HttpContext.Request.Form["firstChoice"]));
 
         var secondChoice = await _dbContext.ProgrammeModel.FirstOrDefaultAsync(p =>
             p.Id == Convert.ToInt32(HttpContext.Request.Form["secondChoice"]));
 
         var thirdChoice = await _dbContext.ProgrammeModel.FirstOrDefaultAsync(p =>
             p.Id == Convert.ToInt32(HttpContext.Request.Form["thirdChoice"]));
 
         var country =
             await _dbContext.CountryModel.FirstOrDefaultAsync(p =>
                 p.ID == Convert.ToInt32(HttpContext.Request.Form["nationality"]));
 
         var hall = await _dbContext.HallModel.FirstOrDefaultAsync(h =>
             h.Id == Convert.ToInt32(HttpContext.Request.Form["hall"]));
 
         var school =
             await _dbContext.FormerSchoolModel.FirstOrDefaultAsync(h =>
                 h.Id == Convert.ToInt32(HttpContext.Request.Form["school"]));
         var denomination = await _dbContext.DenominationModel.FirstOrDefaultAsync(r =>
             r.ID == Convert.ToInt32(HttpContext.Request.Form["denomination"]));
 
         var religion =
             await _dbContext.ReligionModel.FirstOrDefaultAsync(r =>
                 r.Id == Convert.ToInt32(HttpContext.Request.Form["religion"]));
 
 
         var formerProgramme = await _dbContext.SHSProgrammes.FirstOrDefaultAsync(r =>
             r.ID == Convert.ToInt32(HttpContext.Request.Form["formerProgramme"]));
 
 
         await _dbContext.ApplicantModel.AddAsync(
             new ApplicantModel
             {
                 FirstName = HttpContext.Request.Form["fname"],
                 LastName = HttpContext.Request.Form["surname"],
                 DateOfBirth = dateOfBirth,
 
                 ApplicationUser = formData,
                 ApplicationUserId = formData.Id,
 
                 EntryMode = HttpContext.Request.Form["mode"],
                 PreviousName = HttpContext.Request.Form["previousName"],
                 MiddleName = HttpContext.Request.Form["othernames"],
                 Gender = HttpContext.Request.Form["gender"],
                 MaritalStatus = HttpContext.Request.Form["maritalStatus"],
                 Title = HttpContext.Request.Form["title"],
                 Age = _helper.GetAge(dateOfBirth).ToString(),
 
                 ApplicationNumber = Convert.ToInt32(ApplicantForm),
                 EmergencyContact = HttpContext.Request.Form["emergency"],
                 Phone = HttpContext.Request.Form["phone"],
                 AltPhone = HttpContext.Request.Form["altPhone"],
                 Email = HttpContext.Request.Form["email"],
                 Address = HttpContext.Request.Form["address"],
                 PostGPRS = HttpContext.Request.Form["postGPRS"],
                 NationalIDType = HttpContext.Request.Form["NationalityId"],
                 NationalIDNo = HttpContext.Request.Form["NationalityName"],
                 Hometown = HttpContext.Request.Form["hometown"],
                 ResidentialStatus = Convert.ToBoolean(HttpContext.Request.Form["resident"]),
 
                 GuardianName = HttpContext.Request.Form["guardianName"],
                 GuardianRelationship = HttpContext.Request.Form["guardianRelationship"],
 
                 GuardianPhone = HttpContext.Request.Form["guardianPhone"],
                 GuardianOccupation = HttpContext.Request.Form["guardianOccupation"],
 
                 Disability = Convert.ToBoolean(HttpContext.Request.Form["disability"]),
 
                 DisabilityType = HttpContext.Request.Form["disabilityType"],
 
                 FormerSchool = HttpContext.Request.Form["school"],
 
                 Denomination = HttpContext.Request.Form["denomination"],
 
                 Referrals = HttpContext.Request.Form["Referal"],
                 FirstQualification = HttpContext.Request.Form["FirstQualification"],
                 SecondQualification = HttpContext.Request.Form["SecondQualification"],
                 ProgrammeStudied = HttpContext.Request.Form["programme"],
                 LastYearInSchool = Convert.ToInt32(HttpContext.Request.Form["year"]),
                 Awaiting = Convert.ToBoolean(HttpContext.Request.Form["awaiting"]),
                 PreferedHall = HttpContext.Request.Form["hall"],
                 Status = "Applicant",
                 SourceOfFinance = HttpContext.Request.Form["finance"],
 
                 Hall = hall,
                 SponsorShip = Convert.ToBoolean(HttpContext.Request.Form["sponsorship"]),
                 SponsorShipCompany = HttpContext.Request.Form["sponsorshipName"],
                 SponsorShipCompanyContact = HttpContext.Request.Form["SponsorShipCompanyContact"],
                 SponsorShipLocation = HttpContext.Request.Form["SponsorShipLocation"],
 
                 District = district,
                 FirstChoiceId = Convert.ToInt32(HttpContext.Request.Form["firstChoice"]),
                 SecondChoiceId = Convert.ToInt32(HttpContext.Request.Form["secondChoice"]),
                 ThirdChoiceId = Convert.ToInt32(HttpContext.Request.Form["thirdChoice"]),
 
                 Nationality = country,
 
                 Region = region,
                 FormerSchoolNew = school,
                 // School = school,
                 Grade = 0,
                 AdmissionType = "",
                 AdmittedBy = 0,
                 //DateAdmitted = DateTime.ParseExact(HttpContext.Request.Form["dob"], "dd/MM/yyyy", null),
                 DateAdmitted = new DateTime(),
 
                 SectionAdmitted = "",
                 YearOfAdmission = ConfigurationData.Year,
                 Admitted = false,
                 LetterPrinted = false,
                 FeePaying = Convert.ToBoolean(HttpContext.Request.Form["FeePaying"]),
                 ReportedInSchool = false,
                 FeesPaid = Convert.ToDecimal(000.000),
                 Reported = false,
                 Elligible = false,
                 SMSSent = false,
                 Religion = religion,
             });
 
 
         if (await _dbContext.SaveChangesAsync() == 1)
         {
             var applicant = await _dbContext.Users.FindAsync(userId);
 
             applicant.Started = 1;
             if (formData.Type == "MTECH" || formData.Type == "TOPUP" || formData.Type == "ACCELERATED" ||
                 formData.Type == "BRIDGING")
             {
                 formData.FormCompleted = 1;
             }
 
             await _dbContext.SaveChangesAsync();
             return Ok(new
                 {
                     message = "Data saved successfully!!",
                     type = "success",
                 }
             );
         }
         
         return Ok(new
             {
                 message = "Error saving data!!",
                 type = "error",
             }
         );*/
        var form = new ApplicantModel
        {
            ApplicationNumber = Convert.ToInt32(ApplicantForm),
            LastName = applicantForm.LastName,
            FirstName = applicantForm.FirstName
        };
        _dbContext.Add(form);
        await _dbContext.SaveChangesAsync();
        return Ok(200);
    }

    [HttpGet("finalize")]
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