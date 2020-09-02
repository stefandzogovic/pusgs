using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
	public class Destination
	{
		public int DestinationId { get; set; }
		public string Ascenddest { get; set; }
		public string DescendDest { get; set; }
		public List<Flight> Flights { get; set; }
	}
}
