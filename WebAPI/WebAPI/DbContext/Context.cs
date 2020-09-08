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

			builder.Entity<AvioCompany>().HasData(new AvioCompany() {
				AvioCompanyId = 1,
				Address = "Adresa Adresa 123A Novi Sad",
				Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. A deserunt neque tempore recusandae animi soluta quasi? Asperiores rem dolore eaque vel, porro, soluta unde debitis aliquam laboriosam. Repellat explicabo, maiores!",
				Name = "Klisa Airlines"
			});

			builder.Entity<AvioCompany>().HasData(new AvioCompany() {
				AvioCompanyId = 2,
				Address = "Adresa Adresa 123A Novi Sad",
				Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. A deserunt neque tempore recusandae animi soluta quasi? Asperiores rem dolore eaque vel, porro, soluta unde debitis aliquam laboriosam. Repellat explicabo, maiores!",
				Name = "Slana Bara Airlines"
			});

			builder.Entity<Destination>().HasMany(t => t.Flights).WithOne(x => x.Destination).OnDelete(DeleteBehavior.Cascade);
			builder.Entity<User>().HasMany(x => x.Friends);
			builder.Entity<Friend>().HasKey(f => new { f.MainUserId, f.FriendUserId });
			builder.Entity<Friend>().HasOne(f => f.MainUser).WithMany(mu => mu.MainUserFriends).HasForeignKey(f => f.MainUserId).OnDelete(DeleteBehavior.Restrict);
			builder.Entity<Friend>()
			.HasOne(f => f.FriendUser)
			.WithMany(mu => mu.Friends)
			.HasForeignKey(f => f.FriendUserId);

			builder.Entity<Flight>().HasMany(t => t.Stops).WithOne(y => y.Flight).OnDelete(DeleteBehavior.Cascade);
		}

		public DbSet<User> userdb { get; set; }
		public DbSet<Friend> frienddb { get; set; }
		public DbSet<WebAPI.Models.Destination> destinationdb { get; set; }
		public DbSet<AvioCompany> aviocompanydb { get; set; }
		public DbSet<Flight> flightsdb { get; set; }

	}
}
