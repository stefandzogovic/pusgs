using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Flight
    {
		public int FlightId { get; set; }
		public string Dtaascend { get; set; }
		public string Dtadescend { get; set; }
		public int Duration { get; set; }
		public double Distance { get; set; }
		public int Ticketprice { get; set; }
		public List<Stop> Stops { get; set; }

		public int DestinationId { get; set; }
		public Destination Destination { get; set; }
	}
}
