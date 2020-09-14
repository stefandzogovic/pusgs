using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
	public class Reservation
	{
		public int ReservationId { get; set; }
		public int Passport { get; set; }
		public int FlightId { get; set; }
		public Flight Flight { get; set; }
		public int SeatId { get; set; }
		public Seat Seat { get; set; }
		[JsonIgnore]
		public User User { get; set; }
		public int UserId { get; set; }

		public Reservation()
		{

		}
	}
}
