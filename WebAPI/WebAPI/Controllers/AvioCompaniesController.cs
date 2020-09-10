using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Contextt;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvioCompaniesController : ControllerBase
    {
        private readonly Context _context;

        public AvioCompaniesController(Context context)
        {
            _context = context;
        }

        // GET: api/AvioCompanies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AvioCompany>>> Getaviocompanydb()
        {
            return await _context.aviocompanydb.Include(y => y.Destinations)
					.ThenInclude(z => z.Flights)
						.ThenInclude(g => g.Stops)
				.Include(y => y.Destinations)
					.ThenInclude(z => z.Flights)
						.ThenInclude(g => g.Seats).ToListAsync();
        }

        // GET: api/AvioCompanies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AvioCompany>> GetAvioCompany(int id)
        {
			var avioCompany = await _context.aviocompanydb.Where(x => x.AvioCompanyId == id)
				.Include(y => y.Destinations)
					.ThenInclude(z => z.Flights)
						.ThenInclude(g =>g.Stops)
				.Include(y => y.Destinations)
					.ThenInclude(z => z.Flights)
						.ThenInclude(g => g.Seats).FirstOrDefaultAsync();

            if (avioCompany == null)	
            {
                return NotFound();
            }

            return avioCompany;
        }

		// PUT: api/AvioCompanies/5
		// To protect from overposting attacks, enable the specific properties you want to bind to, for
		// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
		[HttpPut("PutFlight/{id}")]
		public async Task<IActionResult> PutFlight(int id, [FromBody]Flight flight)
		{
			if (id != flight.FlightId)
			{
				return BadRequest();
			}

			_context.Entry(flight).State = EntityState.Modified;
			foreach (var x in flight.Seats)
			{
				_context.Entry(x).State = EntityState.Modified;
			}

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!FlightExists(id))
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

		[HttpPut("{id}")]
        public async Task<IActionResult> PutAvioCompany(int id, AvioCompany avioCompany)
        {
            if (id != avioCompany.AvioCompanyId)
            {
                return BadRequest();
            }

            _context.Entry(avioCompany).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AvioCompanyExists(id))
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

		[HttpPost("AddNewDestination/{id}")]
		public async Task<ActionResult<Destination>> PostDestination(int id, [FromBody] Destination destination)
		{
			var company = await _context.aviocompanydb.FindAsync(id);
			destination.AvioCompany = company;
			destination.AvioCompanyId = company.AvioCompanyId;
			_context.destinationdb.Add(destination);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetAvioCompany", new { id = destination.DestinationId }, destination);
		}

		[HttpPost("AddNewFlight/{id}")]
		public async Task<ActionResult<Flight>> PostFlight(int id, [FromBody] Flight flight)
		{
			var destination = await _context.destinationdb.FindAsync(id);
			flight.Destination = destination;
			flight.DestinationId = destination.DestinationId;
			flight.Duration = TimeToInt(flight.Dtaascend, flight.Dtadescend);
			_context.flightsdb.Add(flight);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetAvioCompany", new { id = flight.FlightId }, flight);
		}

		// POST: api/AvioCompanies
		// To protect from overposting attacks, enable the specific properties you want to bind to, for
		// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
		[HttpPost]
        public async Task<ActionResult<AvioCompany>> PostAvioCompany(AvioCompany avioCompany)
        {
            _context.aviocompanydb.Add(avioCompany);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAvioCompany", new { id = avioCompany.AvioCompanyId }, avioCompany);
        }

		[HttpDelete("Flight/{id}")]
		public async Task<ActionResult<Flight>> DeleteFlight(int id)
		{
			var flight = await _context.flightsdb.FindAsync(id);
			if (flight == null)
			{
				return NotFound();
			}

			_context.flightsdb.Remove(flight);
			await _context.SaveChangesAsync();

			return flight;
		}
		// DELETE: api/AvioCompanies/5
		[HttpDelete("{id}")]
        public async Task<ActionResult<AvioCompany>> DeleteAvioCompany(int id)
        {
            var avioCompany = await _context.aviocompanydb.FindAsync(id);
            if (avioCompany == null)
            {
                return NotFound();
            }

            _context.aviocompanydb.Remove(avioCompany);
            await _context.SaveChangesAsync();

            return avioCompany;
        }

		[HttpDelete("Destination/{id}")]
		public async Task<ActionResult<Destination>> DeleteDestination(int id)
		{
			var dest = await _context.destinationdb.FindAsync(id);
			if (dest == null)
			{
				return NotFound();
			}

			_context.destinationdb.Remove(dest);
			await _context.SaveChangesAsync();

			return dest;
		}

		private bool AvioCompanyExists(int id)
        {
            return _context.aviocompanydb.Any(e => e.AvioCompanyId == id);
        }

		private bool FlightExists(int id)
		{
			return _context.flightsdb.Any(e => e.FlightId == id);
		}

		private string TimeToInt(string input1, string input2)
		{
			TimeSpan duration = DateTime.Parse(input2).Subtract(DateTime.Parse(input1));
			if (duration < TimeSpan.Zero)
			{
				duration = duration + TimeSpan.FromDays(1);
			}
			return duration.ToString();
		}
	}
}
