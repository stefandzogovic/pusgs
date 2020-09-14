using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Contextt;
using MailKit.Net.Smtp;
using MimeKit;
using WebAPI.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Hosting;
using MailKit.Security;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RerservationsController : ControllerBase
	{
		private readonly Context _context;
		private readonly IMailer _mailer;

		public RerservationsController(Context context, IMailer mailer)
		{
			_context = context;
			_mailer = mailer;
		}

		[HttpPost]
		public async Task<ActionResult<Reservation>> PostUser([FromBody] Reservation reservation)
		{

			_context.reservationsdb.Add(reservation);
			await _context.SaveChangesAsync();

			return CreatedAtAction("PostReservation", new { id = reservation.ReservationId }, reservation);
		}


		[HttpPost("sendemail/user/{id}")]
		public async Task<ActionResult<Reservation>> SendEmail([FromRoute]int id, [FromBody]Seat seat)
		{
		   var user = await _context.userdb.Include(y => y.Friends)
								   .Include(y => y.Reservations).FirstOrDefaultAsync(x => x.Id == id);
			var html = String.Format("<button <a href='http://localhost:4200/profile/{0}/acceptInvitation/seat{1}}'>Click me</button>", user.Id, seat.SeatId);
			await _mailer.SendMailAsync("stefandzogovicpr26@gmail.com", "Test123", html);
			return NoContent();
		}

		[HttpGet("PostReservation/{id1}/{id2}")]
		public async Task<ActionResult<Reservation>> PostReservation( string id1,  int id2)
		{
			var user = await _context.userdb.Include(y => y.Friends).Include(y => y.Reservations).FirstOrDefaultAsync(x => x.Username == id1);
			var seat = await _context.Seat.FirstOrDefaultAsync(x => x.SeatId == id2);
			var flight = await _context.flightsdb.FirstOrDefaultAsync(x => x.FlightId == seat.FlightId);
			Reservation res = new Reservation();
			res.User = user;
			res.UserId = user.Id;
			res.Seat = seat;
			res.SeatId = seat.SeatId;
			res.FlightId = seat.FlightId;
			res.Flight = seat.Flight;
			seat.Reserved = true;
			_context.Attach(seat);
			_context.Entry(seat).Property("Reserved").IsModified = true;

			_context.reservationsdb.Add(res);
			await _context.SaveChangesAsync();

			return NoContent();

		}

		[HttpGet("GetReservations/{id1}")]
		public async Task<ActionResult<List<Reservation>>> GetReservations(string id1)
		{
			var user = await _context.userdb.Include(y => y.Friends)
								   .Include(y => y.Reservations).ThenInclude(x => x.Seat).FirstOrDefaultAsync(z => z.Username == id1);

			var list = user.Reservations;

			foreach(var r in list)
			{
				r.Seat = await _context.Seat.FirstOrDefaultAsync(m => m.SeatId == r.SeatId);
				r.Flight = await _context.flightsdb.FirstOrDefaultAsync(m => m.FlightId == r.FlightId);
				r.Flight.Destination = await _context.destinationdb.FirstOrDefaultAsync(m => m.DestinationId == r.Flight.DestinationId);
			}

			return list;
		}

	}

	public class SmtpSettings
	{
		public string Server { get; set; }
		public int Port { get; set; }
		public string SenderName { get; set; }
		public string SenderEmail { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
	}
	public interface IMailer
	{
		Task SendMailAsync(string email, string subject, string body);
	}

	public class Mailer : IMailer
	{
		private readonly SmtpSettings _smtpSettings;
		private readonly IWebHostEnvironment _env;

		public Mailer(IOptions<SmtpSettings> smtpsettings, IWebHostEnvironment env)
		{
			_smtpSettings = smtpsettings.Value;
			_env = env;
		}
		public async Task SendMailAsync(string email, string subject, string body)
		{
			try
			{
				MimeMessage message = new MimeMessage();
				message.From.Add(new MailboxAddress(_smtpSettings.SenderName, _smtpSettings.SenderEmail));
				message.To.Add(new MailboxAddress("Stefan Dzogovic", email));
				message.Subject = subject;
				message.Body = new TextPart("html") {
					Text = body
				};

				using (var client = new SmtpClient())
				{
					client.ServerCertificateValidationCallback = (s, c, h, e) => true;
					if (_env.IsDevelopment())
					{
						client.AuthenticationMechanisms.Remove("XOAUTH2");

						await client.ConnectAsync(_smtpSettings.Server, _smtpSettings.Port, SecureSocketOptions.StartTls);
					}
					else
						await client.ConnectAsync(_smtpSettings.Server);

					await client.AuthenticateAsync(_smtpSettings.Username, _smtpSettings.Password);
					await client.SendAsync(message);
					await client.DisconnectAsync(true);
				}
			}
			catch (Exception e)
			{
				throw new InvalidOperationException(e.Message);
			}
			await Task.CompletedTask;
		}

	}
}
