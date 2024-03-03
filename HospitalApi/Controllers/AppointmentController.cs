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
    public class AppointmentController : ControllerBase
    {
        private readonly db_hospitalContext _context;

        public AppointmentController()
        {
            _context = new db_hospitalContext();
        }

        // GET: api/Appointment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbAppointment>>> GetTbAppointments()
        {
          if (_context.TbAppointments == null)
          {
              return NotFound();
          }
            return await _context.TbAppointments.ToListAsync();
        }

        // GET: api/Appointment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbAppointment>> GetTbAppointment(int id)
        {
          if (_context.TbAppointments == null)
          {
              return NotFound();
          }
            var tbAppointment = await _context.TbAppointments.FindAsync(id);

            if (tbAppointment == null)
            {
                return NotFound();
            }

            return tbAppointment;
        }

        // PUT: api/Appointment/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbAppointment(int id, TbAppointment tbAppointment)
        {
            if (id != tbAppointment.AppointmentsId)
            {
                return BadRequest();
            }

            _context.Entry(tbAppointment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbAppointmentExists(id))
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

        // POST: api/Appointment
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbAppointment>> PostTbAppointment(TbAppointment tbAppointment)
        {
          if (_context.TbAppointments == null)
          {
              return Problem("Entity set 'db_hospitalContext.TbAppointments'  is null.");
          }
            _context.TbAppointments.Add(tbAppointment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbAppointment", new { id = tbAppointment.AppointmentsId }, tbAppointment);
        }

        // DELETE: api/Appointment/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbAppointment(int id)
        {
            if (_context.TbAppointments == null)
            {
                return NotFound();
            }
            var tbAppointment = await _context.TbAppointments.FindAsync(id);
            if (tbAppointment == null)
            {
                return NotFound();
            }

            _context.TbAppointments.Remove(tbAppointment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbAppointmentExists(int id)
        {
            return (_context.TbAppointments?.Any(e => e.AppointmentsId == id)).GetValueOrDefault();
        }
    }
}
