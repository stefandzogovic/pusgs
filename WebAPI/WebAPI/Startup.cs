using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebAPI.Contextt;
using WebAPI.Controllers;

namespace WebAPI
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			//services.AddControllers();
			services.Configure<SmtpSettings>(Configuration.GetSection("SmtpSettings"));
			services.AddSingleton<IMailer, Mailer>();
			services.AddControllers().AddJsonOptions(options => //da bi json tipovi pri HTTP metodama bili isti kao u propertiji
			{
				options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
				options.JsonSerializerOptions.PropertyNamingPolicy = null;
			})
			//.AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
			.ConfigureApiBehaviorOptions(options =>
			{
				options.SuppressConsumesConstraintForFormFileParameters = true;
				options.SuppressInferBindingSourcesForParameters = true;
				options.SuppressModelStateInvalidFilter = true;
				options.SuppressMapClientErrors = true;
				options.ClientErrorMapping[StatusCodes.Status404NotFound].Link =
			  "https://httpstatuses.com/404";
			});
			services.AddCors(); //povezivanje sa angular ..CORS

			services.AddDbContext<Context>(options =>
			options.UseSqlServer(Configuration.GetConnectionString("Connection"))); //connection string u appsettings.json fajlu

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			app.UseCors(a => a.SetIsOriginAllowed(x => _ = true)
			.AllowAnyMethod()
			.AllowAnyHeader()
			.AllowCredentials());

			//app.UseMvc();
			app.UseHttpsRedirection();
			//app.UseStatusCodePagesWithReExecute("/");
			//app.UseDefaultFiles();
			//app.UseStaticFiles();
			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
