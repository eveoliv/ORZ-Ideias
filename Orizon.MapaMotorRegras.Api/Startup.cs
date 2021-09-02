using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Swagger;
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
            services.AddDbContext<MapaMotorContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("MapaMotorRegras"));
            });

            services.AddTransient<IRepository<Regra>, RepositoryBase<Regra>>();
            services.AddTransient<IRepository<RegraDetalhe>, RepositoryBase<RegraDetalhe>>();

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info { Title = "Mapa Motor Regras", Description = "Documentação da API de Regras do Motor", Version = "1.0" });                
            });

            services.AddApiVersioning();
            
        }
        
        public void Configure(IApplicationBuilder app)
        {           
            app.UseAuthentication();
           
            app.UseSwagger();

            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");                
            });
        }
    }
}
