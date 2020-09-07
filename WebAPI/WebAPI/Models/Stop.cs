using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;


namespace WebAPI.Models
{
	public class Stop
	{
		public int StopId { get; set; }
		public string City { get; set; }
		public string Country { get; set; }
		public string State { get; set; }

		public int? FlightId { get; set; }
		[JsonIgnore]
		public Flight Flight { get; set; }

		public Stop()
		{

		}
	}
}
