using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
	public class Friend
	{
		public int MainUserId { get; set; }

		public User MainUser { get; set; }

		public int FriendUserId { get; set; }

		public User FriendUser { get; set; }

		public bool Accepted { get; set; }
	}
}
