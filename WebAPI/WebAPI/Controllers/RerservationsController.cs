using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Contextt;
using WebAPI.Models;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RerservationsController : ControllerBase
	{
		private readonly Context _context;

		public RerservationsController(Context context)
		{
			_context = context;
		}

		[HttpPost]
		public async Task<ActionResult<Reservation>> PostUser([FromBody] Reservation reservation)
		{

			_context.reservationsdb.Add(reservation);
			await _context.SaveChangesAsync();

			return CreatedAtAction("PostReservation", new { id = reservation.ReservationId }, reservation);
		}
	}
}
