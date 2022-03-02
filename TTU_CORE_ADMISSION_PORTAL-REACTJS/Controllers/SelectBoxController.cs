using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TTU_CORE_ADMISSION_PORTAL_REACTJS.Data;

namespace TTU_CORE_ADMISSION_PORTAL_REACTJS.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SelectBoxController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        // GET: api/SelectBox
        public SelectBoxController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        [Route("/programmes")]
        public SelectList GetProgrammes(string FormType)
        {
            List<SelectListItem> programme;
            if (FormType == "DIPLOMA")
            {
                FormType = "DipTECH";
            }
            if (FormType == "MTECH")
            {
                FormType = "POSTGRADUATE";
            }

            if (FormType == "DEGREE")
            {
                FormType = "BTECH";
            }
            if (FormType == "TOPUP")
            {
                FormType = "BTECH";
            }
            if (FormType == "BTECH")
            {
                FormType = "BTECH";
            }
            if (FormType == "MATURE")
            {
                FormType = "HND";
            }
            if (FormType == "BRIDGING")
            {
                FormType = "BTECH";
            }
            if (FormType == "ACCELERATED")
            {
                FormType = "BTECH";
            }
            if (FormType == "TOPUP")
            {
                FormType = "HND";
            }
            
            programme = _dbContext.ProgrammeModel.AsNoTracking()
                .OrderBy(n => n.Name)
                .Where(n => n.Type== FormType)
                .Select(n =>
                    new SelectListItem
                    {
                        Value = n.Id.ToString(),
                        Text = n.Name
                    }).ToList();

            return new SelectList(programme, "Value", "Text");
         
        }

       

        
    }
}
