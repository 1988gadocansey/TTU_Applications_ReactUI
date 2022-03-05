#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TTU_CORE_ADMISSION_PORTAL_REACTJS.Data;
using TTU_CORE_ADMISSION_PORTAL_REACTJS.Models;

namespace TTU_CORE_ADMISSION_PORTAL_REACTJS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalenderController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CalenderController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Calender
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConfigurationModel>>> GetConfigurationModel()
        {
            return await _context.ConfigurationModel.ToListAsync();
        }

        // GET: api/Calender/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConfigurationModel>> GetConfigurationModel(int id)
        {
            var configurationModel = await _context.ConfigurationModel.FindAsync(id);

            if (configurationModel == null)
            {
                return NotFound();
            }

            return configurationModel;
        }

        // PUT: api/Calender/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConfigurationModel(int id, ConfigurationModel configurationModel)
        {
            if (id != configurationModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(configurationModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConfigurationModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Calender
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ConfigurationModel>> PostConfigurationModel(ConfigurationModel configurationModel)
        {
            _context.ConfigurationModel.Add(configurationModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConfigurationModel", new { id = configurationModel.Id }, configurationModel);
        }

        // DELETE: api/Calender/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConfigurationModel(int id)
        {
            var configurationModel = await _context.ConfigurationModel.FindAsync(id);
            if (configurationModel == null)
            {
                return NotFound();
            }

            _context.ConfigurationModel.Remove(configurationModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConfigurationModelExists(int id)
        {
            return _context.ConfigurationModel.Any(e => e.Id == id);
        }
    }
}
