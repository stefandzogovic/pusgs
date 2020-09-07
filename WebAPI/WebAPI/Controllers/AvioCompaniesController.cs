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
            return await _context.aviocompanydb.ToListAsync();
        }

        // GET: api/AvioCompanies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AvioCompany>> GetAvioCompany(int id)
        {
            var avioCompany = await _context.aviocompanydb.Where(x => x.AvioCompanyId == id).Include("Destinations.Flights").FirstOrDefaultAsync();

            if (avioCompany == null)
            {
                return NotFound();
            }

            return avioCompany;
        }

        // PUT: api/AvioCompanies/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
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
		public async Task<ActionResult<Destination>> PutDestination(int id, [FromBody] Destination destination)
		{
			var company = await _context.aviocompanydb.FindAsync(id);
			destination.AvioCompany = company;
			destination.AvioCompanyId = company.AvioCompanyId;
			_context.destinationdb.Add(destination);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetAvioCompany", new { id = destination.DestinationId }, destination);
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
    }
}
