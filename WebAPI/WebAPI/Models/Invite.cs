using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
	public class Invite
	{
		public int FriendUserId { get; set; }
		public int MainUserId { get; set; }

		public int ReservationId { get; set; }
		public Reservation Reservation { get; set; }

		public bool Accepted { get; set; } 

		public Invite()
		{
		}
		public Invite(bool accepted)
		{
			Accepted = accepted;
		}
	}
}
