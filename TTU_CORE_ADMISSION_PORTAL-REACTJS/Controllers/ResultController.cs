using System.Collections;
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
    public class ResultController : ControllerBase
    {
        private readonly ILogger<ResultController> _logger;


        private readonly ApplicationDbContext _dbContext;

        private readonly IHttpContextAccessor _httpContextAccessor;
        private UserManager<ApplicationUser> _userManager;

        public ResultController(ILogger<ResultController> logger, UserManager<ApplicationUser> userManager,
            ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _userManager = userManager;
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            _logger.LogInformation("User viewed results.");
            var _formService = new FormService(_dbContext);
            var ApplicantId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId
            var ApplicantName = User.FindFirstValue(ClaimTypes.Name); // will give the user's userName

            var applicationUser = await _userManager.GetUserAsync(User);


            var FormFinalized = applicationUser?.Finalized;

            // applicant details
            var applicant =
                await _dbContext.ApplicantModel.FirstOrDefaultAsync(a => a.ApplicationUserId == ApplicantId);

            if (FormFinalized == 1)
            {
                return RedirectToAction("Index", "Preview");
            }

            if (applicationUser.ResultUploaded == true)
            {
                var results = _dbContext.ResultUploadModel.Include(g => g.Grade)
                    .Include(s => s.Subject)
                    .Where(r => r.ApplicantModelID == applicant.ID).OrderBy(s => s.Year);


                var Core = new int[10];
                var CoreAlt = new int[10];
                var Electives = new int[10];

                foreach (var score in results)
                {
                    switch (score.Subject.Type)
                    {
                        case "core":
                            Array.Fill(Core, Convert.ToInt32(score.Grade.Value));
                            break;
                        case "core_alt":
                            Array.Fill(CoreAlt, Convert.ToInt32(score.Grade.Value));
                            break;
                        case "elective":
                            Array.Fill(Electives, Convert.ToInt32(score.Grade.Value));
                            break;
                    }
                }

                var grades_ = _formService.GetTotalAggregate(Core, CoreAlt, Electives);
                return Ok(new
                {
                    years = _formService.GetYears(), subjects = _formService.GetSubjects(),
                    types = _formService.GetExamTypes(),
                    gradeType = _formService.GetGrades(),
                    result = results,
                    grade = grades_
                });
            }
            else
            {
                return Ok(new
                {
                    years = _formService.GetYears(), subjects = _formService.GetSubjects(),
                    grades = _formService.GetGrades(),
                    types = _formService.GetExamTypes()
                });
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveAysnc()
        {
            //        Character character = await _context.Characters
            //.FirstOrDefaultAsync(c => c.Id == newWeapon.CharacterId &&
            //c.User.Id == int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)));

            FormService _formService = new FormService(_dbContext);

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId


            ApplicationUser applicationUser = await _userManager.GetUserAsync(User);

            //int years = Convert.ToInt32(HttpContext.Request.Form["year"]);

            // array to hold form inputs


            var results = new ArrayList();

            var ApplicantForm = applicationUser?.FormNo;

            var applicant =
                await _dbContext.ApplicantModel.FirstOrDefaultAsync(n =>
                    n.ApplicationNumber == Convert.ToInt32(ApplicantForm));

            string[] year = HttpContext.Request.Form["items[year]"];

            string[] month = HttpContext.Request.Form["items[month]"];

            string[] grade = HttpContext.Request.Form["items[grade]"];

            string[] subject = HttpContext.Request.Form["items[subject]"];

            string[] sitting = HttpContext.Request.Form["items[sitting]"];

            string[] indexno = HttpContext.Request.Form["items[indexno]"];

            string[] center = HttpContext.Request.Form["items[center]"];

            string[] type = HttpContext.Request.Form["items[type]"];
            //int[] Core;
            //int[] CoreAlt;
            // int[] Electives;
            Console.Write("type length is  " + type.Length);
            var Core = new int[8];
            var CoreAlt = new int[7];
            var Electives = new int[20];

            if (year.Length >= 0 && month.Length >= 0 && grade.Length >= 0 && subject.Length >= 0 &&
                sitting.Length >= 0 && indexno.Length >= 0 && center.Length >= 0 && type.Length >= 0)
            {
                int i = 0;
                //if (applicant.NationalityId == 239 || applicant.NationalityId != 58)
                //{

                if (applicationUser.Type != "TOPUP" || applicationUser.Type != "MTECH")
                {
                    for (i = 0; i < type.Length; i++)
                    {
                        var subjects =
                            await _dbContext.SubjectModel.FirstOrDefaultAsync(s => s.Id == Convert.ToInt32(subject[i]));

                        var grades =
                            await _dbContext.GradeModel.FirstOrDefaultAsync(g => g.Id == Convert.ToInt32(grade[i]));

                        await _dbContext.ResultUploadModel.AddRangeAsync(
                            new ResultUploadModel
                            {
                                Applicant = applicant.ID,
                                Subject = subjects,
                                ApplicantModelID = applicant.ID,
                                Sitting = sitting[i],
                                ExamType = type[i],
                                Center = center[i].ToString(),
                                IndexNo = indexno[i].ToString(),
                                Month = month[i].ToString(),
                                Year = year[i].ToString(),
                                Grade = grades
                            });
                        // Console.WriteLine("insert..");

                        if (await _dbContext.ResultUploadModel.AnyAsync(c =>
                                c.Subject == subjects && c.Grade == grades && c.Year == year[i].ToString() &&
                                c.ExamType == type[i] && c.IndexNo == indexno[i].ToString() &&
                                c.Sitting == sitting[i] && c.Month == month[i].ToString() &&
                                c.ApplicantModelID == applicant.ID) == true)
                        {
                            return Ok(new
                                { message = "Error uploading result!!. Result already uploaded", type = "error" });
                        }
                        else
                        {
                            await _dbContext.SaveChangesAsync();
                        }
                    }

                    var resultsData = _dbContext.ResultUploadModel.Include(g => g.Grade)
                        .Include(s => s.Subject)
                        .Where(r => r.ApplicantModelID == applicant.ID);

                    foreach (var score in resultsData)
                    {
                        switch (score.Subject.Type)
                        {
                            case "core":
                                Array.Fill(Core, Convert.ToInt32(score.Grade.Value));
                                break;
                            case "core_alt":
                                Array.Fill(CoreAlt, Convert.ToInt32(score.Grade.Value));
                                break;
                            case "elective":
                                Array.Fill(Electives, Convert.ToInt32(score.Grade.Value));
                                break;
                        }
                    }

                    var grades_ = _formService.GetTotalAggregate(Core, CoreAlt, Electives);

                    var gradeValues = new List<int>();

                    gradeValues.AddRange(Core);
                    gradeValues.AddRange(CoreAlt);
                    gradeValues.AddRange(Electives);

                    var resultsArray = gradeValues.ToArray();

                    var failed = _formService.checkFailed(resultsArray);

                    var passed = _formService.checkPassed(resultsArray);

                    // update grade and result for applicant

                    var applicantData =
                        await _dbContext.ApplicantModel.FirstOrDefaultAsync(a => a.ApplicationUserId == userId);

                    applicantData.Grade = grades_;

                    applicantData.Results = "Total Failed: " + failed + ", Total Passed " + passed;


                    await _dbContext.SaveChangesAsync();


                    var applicantAuth = await _dbContext.Users.FindAsync(userId);

                    applicantAuth.ResultUploaded = true;
                    applicantAuth.Admitted = false;
                    applicantAuth.FormCompleted = 1;

                    await _dbContext.SaveChangesAsync();


                    if (_formService.GradesIssues(Core, CoreAlt, Electives) != null)
                    {
                        foreach (var arg in _formService.GradesIssues(Core, CoreAlt, Electives))
                        {
                            await _dbContext.ApplicantIssueModel.AddAsync(
                                new ApplicantIssueModel
                                {
                                    ApplicantModelID = applicant.ID,
                                    Results = true,
                                    IssuesOne = arg
                                });
                            await _dbContext.SaveChangesAsync();
                        }
                    }


                    Console.WriteLine("grade is " + Core.ToString());

                    return Ok(new
                        { message = "Result(s) uploaded successfully!!", type = "success", grades = grades_ });
                }
            }
            else
            {
                return Ok(new { message = "Please fill in all the form elements!!", type = "error" });
            }

            return Ok();
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId


            var applicationUser = await _userManager.GetUserAsync(User);


            var ApplicantForm = applicationUser?.FormNo;

            var applicant =
                await _dbContext.ApplicantModel.FirstOrDefaultAsync(n =>
                    n.ApplicationNumber == Convert.ToInt32(ApplicantForm));


            var resultModel = await _dbContext.ResultUploadModel.FindAsync(id);
            _dbContext.ResultUploadModel.Remove(resultModel);

            if (await _dbContext.SaveChangesAsync() == 1)
            {
                var data = _dbContext.ResultUploadModel.Where(r => r.ApplicantModelID == applicant.ID);
                if (data == null)
                {
                    var applicantAuth = await _dbContext.Users.FindAsync(userId);

                    applicantAuth.ResultUploaded = false;


                    await _dbContext.SaveChangesAsync();

                    var applicantInfo =
                        await _dbContext.ApplicantModel.FirstOrDefaultAsync(n =>
                            n.ApplicationNumber == Convert.ToInt32(ApplicantForm));

                    applicantInfo.Results = "";
                    applicantInfo.Grade = 0;

                    await _dbContext.SaveChangesAsync();
                }
            }

            var result = _dbContext.ResultUploadModel.Where(r => r.ApplicantModelID == applicant.ID);
            Console.WriteLine("result is " + result);

            return Ok(new { results = result });
        }
    }
}