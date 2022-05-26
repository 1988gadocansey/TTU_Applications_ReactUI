using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TTU_CORE_ADMISSION_PORTAL_REACTJS.Data;
using TTU_CORE_ADMISSION_PORTAL_REACTJS.Models;
using TTU_CORE_ADMISSION_PORTAL_REACTJS.Services;

namespace TTU_CORE_ADMISSION_PORTAL_REACTJS.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class PreviewController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        private readonly IHttpContextAccessor _httpContextAccessor;
        private UserManager<ApplicationUser> _userManager;
        private readonly IHelper _helper;
        private readonly ILogger<PreviewController> _logger;

        public PreviewController(ILogger<PreviewController> logger, IHelper helper,
            UserManager<ApplicationUser> userManager, ApplicationDbContext dbContext,
            IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _userManager = userManager;
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
            _helper = helper;
        }


        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            _logger.LogInformation("User visited preview page.");
            var _formService = new FormService(_dbContext);

            var ApplicantId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId
            var ApplicantName = User.FindFirstValue(ClaimTypes.Name); // will give the user's userName

            var applicationUser = await _userManager.GetUserAsync(User);

            var ApplicantForm = applicationUser?.FormNo;

            var ApplicationYear = applicationUser?.Year;

            var FormFinalized = applicationUser?.Finalized;

            var ApplicantPin = applicationUser?.Pin;
            var ApplicantFormType = applicationUser?.Type;

            string[] LegacyYears = { "2017", "2018", "2019", "2020" };

            // check if the user completed the form send him sms
            if (Array.Find(LegacyYears, element => element == ApplicationYear) != null)
            {
                var applicant = await _dbContext.ApplicantModel
                    .FirstOrDefaultAsync(a => a.ApplicationNumber.ToString() == ApplicantForm);
                // ViewData["applicant"] = applicant;

                var results = _dbContext.ResultUploadModel
                    .Include(s => s.Subject).Where(r => r.Form == Convert.ToInt32(ApplicantForm)).OrderBy(s => s.Year);


                if (results == null)
                {
                    var ResultsOld = _dbContext.ResultUploadModel
                        .Include(s => s.Subject).Where(r => r.Applicant == applicant.ID).OrderBy(s => s.Year);
                }
                //ViewData["results"] = results;


               // return Ok("legacy");
                return Ok(new { applicant = applicant, results = results });
            }
            else
            {
                //var applicant = await _dbContext.ApplicantModel.FirstOrDefaultAsync(a => a.ApplicationUserId == ApplicantId);
                var applicant = await _dbContext.ApplicantModel.Include(r => r.Region).Include(n => n.Nationality)
                    .Include(p => p.Programmes)
                    .Include(a => a.ApplicationUser)
                    .Include(h => h.Hall)
                    .Include(rel => rel.Religion)
                    .Include(s => s.FormerSchoolNew)
                    .Include(r => r.ResultUploads)
                    .Include(d => d.District)
                    .FirstOrDefaultAsync(a => a.ApplicationUserId == ApplicantId);


                //ViewData["applicant"] = applicant;

                var results = _dbContext.ResultUploadModel.Include(g => g.Grade)
                    .Include(s => s.Subject).Where(r => r.ApplicantModelID == applicant.ID).OrderBy(s => s.Year);


                //ViewData["results"] = results;


                return Ok(new { applicant = applicant, results = results });
            }
        }
    }
}