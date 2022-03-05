using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TTU_CORE_ADMISSION_PORTAL_REACTJS.Data;
using TTU_CORE_ADMISSION_PORTAL_REACTJS.Models;

namespace TTU_CORE_ADMISSION_PORTAL_REACTJS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SelectBoxController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        // GET: api/SelectBox
        public SelectBoxController(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }
        [HttpGet("toys")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("programmes")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProgrammeModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IEnumerable<SelectListItem>  GetProgrammes()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var formData = _dbContext.Users.FirstOrDefault(a => a.Id == userId);
            var userFormType = formData?.Type;
            var types = new Dictionary<string, string>
            {
                { "DIPLOMA", "DipTECH" },
                { "MTECH", "MTECH" },
                { "DEGREE", "DEGREE" },
                { "TOPUP", "HND" },
                { "MATURE", "HND" },
                { "BTECH", "DEGREE" },
                { "BRIDGING", "BTECH" },
                { "HND", "HND" },
                { "ACCELERATED", "BTECH" }
            };
            var formType = types.FirstOrDefault(x => x.Value == userFormType).Value;
            List<SelectListItem> programme;

            programme = _dbContext.ProgrammeModel.AsNoTracking()
                .OrderBy(n => n.Name)
                .Where(n => n.Type == formType)
                .Select(n =>
                    new SelectListItem
                    {
                        Value = n.Id.ToString(),
                        Text = n.Name
                    }).ToList();

            return new SelectList(programme, "Value", "Text");
        }

        [HttpGet("districts")]
        public IEnumerable<SelectListItem>  GetDistrict()
        {
            return new SelectList(_dbContext.DistrictModel, "ID", "Name");
        }

        [HttpGet("religions")]
        public IEnumerable<SelectListItem>  GetReligions()
        {
            return new SelectList(_dbContext.ReligionModel, "Id", "Name");
        }

        [HttpGet("denomination")]
        public IEnumerable<SelectListItem> GetDenominations()
        {
            return new SelectList(_dbContext.DenominationModel, "ID", "Name");
        }

        [HttpGet("shsprogrammes")]
        public IEnumerable<SelectListItem>  GetSHSProgrammes()
        {
            return new SelectList(_dbContext.SHSProgrammes, "Name", "Name");
        }

        [HttpGet("grades")]
        public IEnumerable<SelectListItem>  GetGrades()
        {
            var grades = _dbContext.GradeModel.AsNoTracking()
                .OrderBy(n => n.Name)
                .Select(n =>
                    new SelectListItem
                    {
                        Value = n.Id.ToString(),
                        Text = n.Name
                    }).ToList();

            return new SelectList(grades, "Value", "Text");
        }

        [HttpGet("examtypes")]
        public IEnumerable<SelectListItem>  GetExamTypes()
        {
            var exams = _dbContext.ExamModel.AsNoTracking()
                .OrderBy(n => n.Name)
                .Select(n =>
                    new SelectListItem
                    {
                        Value = n.Name,
                        Text = n.Name
                    }).ToList();

            return new SelectList(exams, "Value", "Text");
        }

        [HttpGet("years")]
        public object GetYears()
        {
            const int startYear = 1980;
            var years = Enumerable.Range(startYear, (DateTime.Now.Year - startYear + 1));
            return years;
        }
        [HttpGet("halls")]
        public IEnumerable<SelectListItem> GetHalls()
        {
            return new SelectList(_dbContext.HallModel, "Id", "Name");
        }
        [HttpGet("subjects")]
        public IEnumerable<SelectListItem> GetSubjects()
        {
            var subjects = _dbContext.SubjectModel.AsNoTracking()
                .OrderBy(n => n.Name)
                .Select(n =>
                    new SelectListItem
                    {
                        Value = n.Id.ToString(),
                        Text = n.Name
                    }).ToList();

            return new SelectList(subjects, "Value", "Text");

        }
        [HttpGet("schools")]
        public IEnumerable<SelectListItem> GetSchools()
        {
            var schools = _dbContext.FormerSchoolModel.AsNoTracking()
                .OrderBy(n => n.Name)
                
                .Select(n =>
                    new SelectListItem
                    {
                        Value = n.Id.ToString(),
                        Text = n.Name
                    }).ToList();

            return new SelectList(schools, "Value", "Text");
        }
        

    }
}