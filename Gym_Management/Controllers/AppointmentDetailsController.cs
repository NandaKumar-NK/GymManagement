using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gym_Management.Models;

namespace Gym_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentDetailsController : ControllerBase
    {
        private readonly DBContext _context;

        public AppointmentDetailsController(DBContext context)
        {
            _context = context;
        }

        // GET: api/AppointmentDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppointmentDetails>>> GetAppointmentsDetails()
        {
          if (_context.AppointmentsDetails == null)
          {
              return NotFound();
          }
            return await _context.AppointmentsDetails.ToListAsync();
        }

        // GET: api/AppointmentDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AppointmentDetails>> GetAppointmentDetails(int id)
        {
          if (_context.AppointmentsDetails == null)
          {
              return NotFound();
          }
            var appointmentDetails = await _context.AppointmentsDetails.FindAsync(id);

            if (appointmentDetails == null)
            {
                return NotFound();
            }

            return appointmentDetails;
        }

        // PUT: api/AppointmentDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppointmentDetails(int id, AppointmentDetails appointmentDetails)
        {
            if (id != appointmentDetails.AppointmentId)
            {
                return BadRequest();
            }

            _context.Entry(appointmentDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppointmentDetailsExists(id))
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

        // POST: api/AppointmentDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AppointmentDetails>> PostAppointmentDetails(AppointmentDetails appointmentDetails)
        {
          if (_context.AppointmentsDetails == null)
          {
              return Problem("Entity set 'DatabaseContext.AppointmentsDetails'  is null.");
          }
            _context.AppointmentsDetails.Add(appointmentDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAppointmentDetails", new { id = appointmentDetails.AppointmentId }, appointmentDetails);
        }

        // DELETE: api/AppointmentDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointmentDetails(int id)
        {
            if (_context.AppointmentsDetails == null)
            {
                return NotFound();
            }
            var appointmentDetails = await _context.AppointmentsDetails.FindAsync(id);
            if (appointmentDetails == null)
            {
                return NotFound();
            }

            _context.AppointmentsDetails.Remove(appointmentDetails);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AppointmentDetailsExists(int id)
        {
            return (_context.AppointmentsDetails?.Any(e => e.AppointmentId == id)).GetValueOrDefault();
        }
    }
}
