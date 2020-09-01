using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using WebAPI.Contextt;
using WebAPI.Models;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FriendsController : ControllerBase
	{
		private readonly Context _context;

		public FriendsController(Context context)
		{
			_context = context;
		}

		// GET: api/Friends
		[HttpGet]
		public async Task<ActionResult<IEnumerable<User>>> GetFriend([FromQuery(Name = "var1")] int id)
		{
			List<Friend> x = await _context.frienddb.Where(x => x.MainUserId != id).Where(p => p.FriendUserId == id).Where(y => y.Accepted == true).Select(z => z).ToListAsync();
			List<User> list = new List<User>();

			foreach (Friend f in x)
			{
				list = await _context.userdb.Where(x => x.Id == f.MainUserId).Select(y => y).ToListAsync();
			}
			return list;
		}


		[Route("Requests")]
		public async Task<ActionResult<List<User>>> GetRequests([FromQuery(Name = "var1")]int id)
		{
			List<Friend> x = await _context.frienddb.Where(x => x.MainUserId != id).Where(p => p.FriendUserId == id).Where(y => y.Accepted == false).Select(z => z).ToListAsync();
			List<User> list = new List<User>();
			foreach(Friend f in x)
			{
				list = await _context.userdb.Where(x => x.Id == f.MainUserId).Select(y => y).ToListAsync();
			}

			return list;
		}
		// GET: api/Friends/5
		//[HttpGet("{id}")]
		//public async Task<ActionResult<Friend>> GetFriend(int id)
		//{
		//	var friend = await _context.frienddb.FindAsync(id);

		//	if (friend == null)
		//	{
		//		return NotFound();
		//	}

		//	return friend;
		//}

		// PUT: api/Friends/5
		// To protect from overposting attacks, enable the specific properties you want to bind to, for
		// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
		[HttpGet("Accept/{id1}/{id2}")]
		public async Task<IActionResult> AcceptFriend(int id1, int id2)
		{
			var x = await _context.frienddb.Where(x => x.MainUserId == id2).Where(y => y.FriendUserId == id1).Select(z => z).SingleAsync();
			x.Accepted = true;
			_context.Attach(x);
			_context.Entry(x).State = EntityState.Modified;
			_context.Entry(x).Property(x => x.Accepted).IsModified = true;   // one field
			await _context.SaveChangesAsync();
			return NoContent();
		}

		[HttpGet("Remove/{id1}/{id2}")]
		public async Task<IActionResult> RemoveFriend(int id1, int id2)
		{
			var x = await _context.frienddb.Where(x => x.MainUserId == id2).Where(y => y.FriendUserId == id1).Select(z => z).SingleAsync();
			_context.frienddb.Remove(x);	
			await _context.SaveChangesAsync();
			return NoContent();
		}


		// POST: api/Friends
		// To protect from overposting attacks, enable the specific properties you want to bind to, for
		// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
		[HttpPost]
		public async Task<ActionResult<Friend>> PostFriend([FromBody] User[] data)
		{

			User arg1 = data[0];
			User arg2 = data[1];

			Friend friend = new Friend();
			User mainuser = await _context.userdb.FindAsync(arg1.Id);
			User frienduser = await _context.userdb.FindAsync(arg2.Id);
			friend.MainUser = mainuser;
			friend.MainUserId = mainuser.Id;
			friend.FriendUser = frienduser;
			friend.FriendUserId = frienduser.Id;


			//mainuser.Friends = await _context.frienddb.Where(x => x.MainUserId == mainuser.Id).Select(x => x).ToListAsync();
			_context.frienddb.Add(friend);

			//_context.Friend.Add(friend);
			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateException)
			{
				if (FriendExists(friend.MainUserId))
				{
					return Conflict();
				}
				else
				{
					throw;
				}
			}

			return CreatedAtAction("GetFriend", new { id = friend.MainUserId }, friend);
		}

		// DELETE: api/Friends/5
		[HttpDelete("{id}")]
		public async Task<ActionResult<Friend>> DeleteFriend(int id)
		{
			var friend = await _context.frienddb.FindAsync(id);
			if (friend == null)
			{
				return NotFound();
			}

			_context.frienddb.Remove(friend);
			await _context.SaveChangesAsync();

			return friend;
		}

		private bool FriendExists(int id)
		{
			return _context.frienddb.Any(e => e.MainUserId == id);
		}
	}
}
