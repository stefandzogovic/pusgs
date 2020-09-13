using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
	public class Reservation
	{
		public int ReservationId { get; set; }
		public int Passport { get; set; }
		public int UserId { get; set; }
		public User User { get; set; }

		public Reservation()
		{

		}
	}
}
