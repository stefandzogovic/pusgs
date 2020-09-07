using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace WebAPI.Models
{
	public class Destination
	{
		public int DestinationId { get; set; }
		public string Ascenddest { get; set; }
		public string Descenddest { get; set; }
		public List<Flight> Flights { get; set; }

		public int AvioCompanyId { get; set; }
		[JsonIgnore]
		public AvioCompany AvioCompany { get; set; }

		public Destination()
		{

		}
	}
}
