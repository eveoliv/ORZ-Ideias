using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Orizon.MapaMotorRegras.Api.Context;
using Orizon.MapaMotorRegras.Api.Entities;
using Orizon.MapaMotorRegras.Api.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Orizon.MapaMotorRegras.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddControllers();

            services.AddApiVersioning();

            services.AddDbContext<MapaMotorContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("MapaMotorRegras"));
            });

            services.AddTransient<IRepository<RegraDetalhe>, RepositoryBase<RegraDetalhe>>();
            services.AddTransient<IRepository<RegraOperadora>, RepositoryBase<RegraOperadora>>();
            services.AddTransient<IRepository<RegraDocumentacao>, RepositoryBase<RegraDocumentacao>>();

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddSwaggerGen();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Mapa Motor Regras",
                    Description = "Documentação da API de Regras do Motor",
                    Version = "1.0"
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthentication();

            app.UseEndpoints(e => e.MapControllers());

            app.UseSwagger();

            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });
        }
    }
}
