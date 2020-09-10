using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebAPI.Models
{
	public class Seat
	{
		public int SeatId { get; set; }
		public bool Reserved { get; set; }
		public string Name { get; set; }
		public int FlightId { get; set; }
		[JsonIgnore]
		public Flight Flight { get; set; }

		public Seat()
		{

		}
	}
}
