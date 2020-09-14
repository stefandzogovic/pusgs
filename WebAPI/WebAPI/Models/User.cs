using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
	public class User
	{
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public string Lastname { get; set; }
		[Required]
		public string Username { get; set; }
		[Required]
		public string Password { get; set; }
		[Required]
		public string Address { get; set; }
		[Required]
		public string Email { get; set; }
		[Required]
		public string Phone { get; set; }
		[Required]
		public string Type { get; set; }

		public List<Reservation> Reservations { get; set; }
		
		public int? AvioCompanyId { get; set; }
		public AvioCompany AvioCompany { get; set; }

		public virtual ICollection<Friend> MainUserFriends { get; set; }

		public virtual ICollection<Friend> Friends { get; set; }

		public User()
		{

		}
	}
}
