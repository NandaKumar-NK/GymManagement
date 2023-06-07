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
    public class TrainersDetailsController : ControllerBase
    {
        private readonly DBContext _context;

        public TrainersDetailsController(DBContext context)
        {
            _context = context;
        }

        // GET: api/TrainersDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrainersDetails>>> GetTrainersDetails()
        {
          if (_context.TrainersDetails == null)
          {
              return NotFound();
          }
            return await _context.TrainersDetails.ToListAsync();
        }

        // GET: api/TrainersDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrainersDetails>> GetTrainersDetails(int? id)
        {
          if (_context.TrainersDetails == null)
          {
              return NotFound();
          }
            var trainersDetails = await _context.TrainersDetails.FindAsync(id);

            if (trainersDetails == null)
            {
                return NotFound();
            }

            return trainersDetails;
        }

        // PUT: api/TrainersDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrainersDetails(int? id, TrainersDetails trainersDetails)
        {
            if (id != trainersDetails.TrainerId)
            {
                return BadRequest();
            }

            _context.Entry(trainersDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainersDetailsExists(id))
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

        // POST: api/TrainersDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TrainersDetails>> PostTrainersDetails(TrainersDetails trainersDetails)
        {
          if (_context.TrainersDetails == null)
          {
              return Problem("Entity set 'DatabaseContext.TrainersDetails'  is null.");
          }
            _context.TrainersDetails.Add(trainersDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrainersDetails", new { id = trainersDetails.TrainerId }, trainersDetails);
        }

        // DELETE: api/TrainersDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrainersDetails(int? id)
        {
            if (_context.TrainersDetails == null)
            {
                return NotFound();
            }
            var trainersDetails = await _context.TrainersDetails.FindAsync(id);
            if (trainersDetails == null)
            {
                return NotFound();
            }

            _context.TrainersDetails.Remove(trainersDetails);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrainersDetailsExists(int? id)
        {
            return (_context.TrainersDetails?.Any(e => e.TrainerId == id)).GetValueOrDefault();
        }
    }
}
