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
    public class PatientController : ControllerBase
    {
        private readonly db_hospitalContext _context;

        public PatientController()
        {
            _context = new db_hospitalContext();
        }

        // GET: api/Patient
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbPatient>>> GetTbPatients()
        {
          if (_context.TbPatients == null)
          {
              return NotFound();
          }
            return await _context.TbPatients.ToListAsync();
        }

        // GET: api/Patient/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbPatient>> GetTbPatient(int id)
        {
          if (_context.TbPatients == null)
          {
              return NotFound();
          }
            var tbPatient = await _context.TbPatients.FindAsync(id);

            if (tbPatient == null)
            {
                return NotFound();
            }

            return tbPatient;
        }

        // PUT: api/Patient/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbPatient(int id, TbPatient tbPatient)
        {
            if (id != tbPatient.PatientId)
            {
                return BadRequest();
            }

            _context.Entry(tbPatient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbPatientExists(id))
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

        // POST: api/Patient
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbPatient>> PostTbPatient(TbPatient tbPatient)
        {
          if (_context.TbPatients == null)
          {
              return Problem("Entity set 'db_hospitalContext.TbPatients'  is null.");
          }
            _context.TbPatients.Add(tbPatient);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbPatient", new { id = tbPatient.PatientId }, tbPatient);
        }

        // DELETE: api/Patient/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbPatient(int id)
        {
            if (_context.TbPatients == null)
            {
                return NotFound();
            }
            var tbPatient = await _context.TbPatients.FindAsync(id);
            if (tbPatient == null)
            {
                return NotFound();
            }

            _context.TbPatients.Remove(tbPatient);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbPatientExists(int id)
        {
            return (_context.TbPatients?.Any(e => e.PatientId == id)).GetValueOrDefault();
        }
    }
}
