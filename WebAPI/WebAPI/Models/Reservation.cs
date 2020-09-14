using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;


namespace WebAPI.Models
{
	public class Reservation
	{
		public int ReservationId { get; set; }
		public int Passport { get; set; }
		public int FlightId { get; set; }
		[JsonIgnore]
		public Flight Flight { get; set; }
		public List<Invite> Invites { get; set; }
		//public User User { get; set; }
		//public int UserId { get; set; }

		public Reservation()
		{

		}
	}
}
