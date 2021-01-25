using AutoMapper;
using Livraria.Data.Context;
using Livraria.Data.Interfaces;
using Livraria.Data.Repositorys;
using Livraria.UseCases.Interfaces;
using Livraria.UseCases.UseCases;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Livraria.WebApi
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
			services.AddDbContext<LivrariaDbContext>(opt =>
			{
				opt.UseSqlServer(Configuration.GetConnectionString("ConnectionDefault"));
			});

			services.AddScoped<ILivroRepository, LivroRepository>();
			services.AddScoped<ILivroUseCases, LivroUseCases>();

			services.AddSwaggerGen(cfg =>
			{
				cfg.SwaggerDoc("v1", new OpenApiInfo
				{
					Title = "Livraria API",
					Description = "API contendo um simples CRUD de livros",
					Version = "v1",
					Contact = new OpenApiContact
					{ 
						Email = "dan.alves300@gmail.com",
						Name = "Danilo Alves",
						Url = new Uri("https://instagram.com/alves.dan_")
					},
					License = new OpenApiLicense
					{
						Url = new Uri("https://www.gnu.org/licenses/gpl-3.0.html"),
						Name = "Licença Livraria API"
					}
				});

				string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
				string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
				cfg.IncludeXmlComments(xmlPath);
			});

			services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

			services.AddControllers();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseSwagger();

			app.UseSwaggerUI(cfg =>
			{
				cfg.SwaggerEndpoint("/swagger/v1/swagger.json", "Livraria API");
				cfg.RoutePrefix = string.Empty;
			});

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
