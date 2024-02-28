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
    public class DoctorController : ControllerBase
    {
        private readonly db_hospitalContext _context;

        public DoctorController(db_hospitalContext context)
        {
            _context = context;
        }

        // GET: api/Doctor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbDoctor>>> GetTbDoctors()
        {
          if (_context.TbDoctors == null)
          {
              return NotFound();
          }
            return await _context.TbDoctors.ToListAsync();
        }

        // GET: api/Doctor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbDoctor>> GetTbDoctor(int id)
        {
          if (_context.TbDoctors == null)
          {
              return NotFound();
          }
            var tbDoctor = await _context.TbDoctors.FindAsync(id);

            if (tbDoctor == null)
            {
                return NotFound();
            }

            return tbDoctor;
        }

        // PUT: api/Doctor/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbDoctor(int id, TbDoctor tbDoctor)
        {
            if (id != tbDoctor.DoctorsId)
            {
                return BadRequest();
            }

            _context.Entry(tbDoctor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbDoctorExists(id))
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

        // POST: api/Doctor
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbDoctor>> PostTbDoctor(TbDoctor tbDoctor)
        {
          if (_context.TbDoctors == null)
          {
              return Problem("Entity set 'db_hospitalContext.TbDoctors'  is null.");
          }
            _context.TbDoctors.Add(tbDoctor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbDoctor", new { id = tbDoctor.DoctorsId }, tbDoctor);
        }

        // DELETE: api/Doctor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbDoctor(int id)
        {
            if (_context.TbDoctors == null)
            {
                return NotFound();
            }
            var tbDoctor = await _context.TbDoctors.FindAsync(id);
            if (tbDoctor == null)
            {
                return NotFound();
            }

            _context.TbDoctors.Remove(tbDoctor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbDoctorExists(int id)
        {
            return (_context.TbDoctors?.Any(e => e.DoctorsId == id)).GetValueOrDefault();
        }
    }
}
