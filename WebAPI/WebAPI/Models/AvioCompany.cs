using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
	public class AvioCompany
	{
		public int AvioCompanyId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Address { get; set; }
		public List<Destination> Destinations { get; set; }
	}
}
