using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace WebAPI.Models
{
	public class Friend
	{
		public int MainUserId { get; set; }

		[JsonIgnore]
		public User MainUser { get; set; }

		public int FriendUserId { get; set; }

		[JsonIgnore]
		public User FriendUser { get; set; }

		public bool Accepted { get; set; }

		public Friend()
		{

		}
		public Friend(bool accepted)
		{
			Accepted = accepted;
		}
	}
}
