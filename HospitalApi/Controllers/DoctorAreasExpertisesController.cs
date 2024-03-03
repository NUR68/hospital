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
    public class DoctorAreasExpertisesController : ControllerBase
    {
        private readonly db_hospitalContext _context;

        public DoctorAreasExpertisesController()
        {
            _context = new db_hospitalContext();
        }

        // GET: api/DoctorAreasExpertises
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbDoctorAreasExpertise>>> GetTbDoctorAreasExpertises()
        {
          if (_context.TbDoctorAreasExpertises == null)
          {
              return NotFound();
          }
            return await _context.TbDoctorAreasExpertises.ToListAsync();
        }

        // GET: api/DoctorAreasExpertises/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbDoctorAreasExpertise>> GetTbDoctorAreasExpertise(int id)
        {
          if (_context.TbDoctorAreasExpertises == null)
          {
              return NotFound();
          }
            var tbDoctorAreasExpertise = await _context.TbDoctorAreasExpertises.FindAsync(id);

            if (tbDoctorAreasExpertise == null)
            {
                return NotFound();
            }

            return tbDoctorAreasExpertise;
        }

        // PUT: api/DoctorAreasExpertises/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbDoctorAreasExpertise(int id, TbDoctorAreasExpertise tbDoctorAreasExpertise)
        {
            if (id != tbDoctorAreasExpertise.ExpertiseId)
            {
                return BadRequest();
            }

            _context.Entry(tbDoctorAreasExpertise).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbDoctorAreasExpertiseExists(id))
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

        // POST: api/DoctorAreasExpertises
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbDoctorAreasExpertise>> PostTbDoctorAreasExpertise(TbDoctorAreasExpertise tbDoctorAreasExpertise)
        {
          if (_context.TbDoctorAreasExpertises == null)
          {
              return Problem("Entity set 'db_hospitalContext.TbDoctorAreasExpertises'  is null.");
          }
            _context.TbDoctorAreasExpertises.Add(tbDoctorAreasExpertise);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbDoctorAreasExpertise", new { id = tbDoctorAreasExpertise.ExpertiseId }, tbDoctorAreasExpertise);
        }

        // DELETE: api/DoctorAreasExpertises/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbDoctorAreasExpertise(int id)
        {
            if (_context.TbDoctorAreasExpertises == null)
            {
                return NotFound();
            }
            var tbDoctorAreasExpertise = await _context.TbDoctorAreasExpertises.FindAsync(id);
            if (tbDoctorAreasExpertise == null)
            {
                return NotFound();
            }

            _context.TbDoctorAreasExpertises.Remove(tbDoctorAreasExpertise);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbDoctorAreasExpertiseExists(int id)
        {
            return (_context.TbDoctorAreasExpertises?.Any(e => e.ExpertiseId == id)).GetValueOrDefault();
        }
    }
}
