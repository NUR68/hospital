using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataLayer.Models;

namespace HospitalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicController : ControllerBase
    {
        private readonly db_hospitalContext _context;

        public ClinicController()
        {
            _context = new db_hospitalContext ();
        }

        // GET: api/Clinic
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbClinic>>> GetTbClinics()
        {
          if (_context.TbClinics == null)
          {
              return NotFound();
          }
            return await _context.TbClinics.ToListAsync();
        }

        // GET: api/Clinic/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbClinic>> GetTbClinic(int id)
        {
          if (_context.TbClinics == null)
          {
              return NotFound();
          }
            var tbClinic = await _context.TbClinics.FindAsync(id);

            if (tbClinic == null)
            {
                return NotFound();
            }

            return tbClinic;
        }

        // PUT: api/Clinic/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbClinic(int id, TbClinic tbClinic)
        {
            if (id != tbClinic.ClinicId)
            {
                return BadRequest();
            }

            _context.Entry(tbClinic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbClinicExists(id))
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

        // POST: api/Clinic
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbClinic>> PostTbClinic(TbClinic tbClinic)
        {
          if (_context.TbClinics == null)
          {
              return Problem("Entity set 'db_hospitalContext.TbClinics'  is null.");
          }
            _context.TbClinics.Add(tbClinic);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbClinic", new { id = tbClinic.ClinicId }, tbClinic);
        }

        // DELETE: api/Clinic/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbClinic(int id)
        {
            if (_context.TbClinics == null)
            {
                return NotFound();
            }
            var tbClinic = await _context.TbClinics.FindAsync(id);
            if (tbClinic == null)
            {
                return NotFound();
            }

            _context.TbClinics.Remove(tbClinic);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbClinicExists(int id)
        {
            return (_context.TbClinics?.Any(e => e.ClinicId == id)).GetValueOrDefault();
        }
    }
}
