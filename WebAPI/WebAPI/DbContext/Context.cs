using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Contextt
{
	public class Context : DbContext
	{
		public Context(DbContextOptions<Context> options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder builder)

		{
			base.OnModelCreating(builder);

			builder.Entity<User>().HasMany(x => x.Friends);
			builder.Entity<Friend>().HasKey(f => new { f.MainUserId, f.FriendUserId });
			builder.Entity<Friend>().HasOne(f => f.MainUser).WithMany(mu => mu.MainUserFriends).HasForeignKey(f => f.MainUserId).OnDelete(DeleteBehavior.Restrict);
			builder.Entity<Friend>()
			.HasOne(f => f.FriendUser)
			.WithMany(mu => mu.Friends)
		    .HasForeignKey(f => f.FriendUserId);

			builder.Entity<Flight>().HasMany(t => t.Stops).WithOne(y => y.Flight);
		}

		public DbSet<User> userdb { get; set; }
		public DbSet<Friend> frienddb { get; set; }

	}
}
