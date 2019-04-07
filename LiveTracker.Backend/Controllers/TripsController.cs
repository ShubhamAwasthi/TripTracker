using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiveTracker.Backend.Data;
using Microsoft.AspNetCore.Mvc;

namespace LiveTracker.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        private TripsContext _context;
        public TripsController(TripsContext context)
        {
            _context = context;
        }
        // GET api/trips
        [HttpGet]
        public ActionResult<IEnumerable<Trip>> Get()
        {
            return _context.Trips.ToList();
        }

        // GET api/trips/5
        [HttpGet("{id}")]
        public ActionResult<Trip> Get(int id)
        {
            var trip = _context.Trips.FirstOrDefault(t => t.Id == id);
            if (trip == null) return NotFound();
            return Ok(trip);
        }

        // POST api/trips
        [HttpPost]
        public IActionResult Post([FromBody] Trip value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Trips.Add(value);
            _context.SaveChanges();
            return NoContent();
        }

        // PUT api/trips/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Trip value)
        {
            if (!_context.Trips.Any(x => x.Id == id))
            {
                return NotFound();
            }
            value.Id = id;
            _context.Trips.Update(value);
            _context.SaveChanges();
            return NoContent();
        }

        // DELETE api/trips/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var trip = _context.Trips.FirstOrDefault(t => t.Id == id);
            if (trip == null) return NotFound();
            _context.Trips.Remove(trip);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
