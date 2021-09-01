using Microsoft.EntityFrameworkCore;
using Orizon.MapaMotorRegras.Api.Entities;

namespace Orizon.MapaMotorRegras.Api.Context
{
    public class MapaMotorContext : DbContext
    {
        public DbSet<Regra> Regras { get; set; }
        public DbSet<RegraDetalhe> RegrasDetalhe { get; set; }

        public MapaMotorContext(DbContextOptions<MapaMotorContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RegraConfiguration());
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RegraDetalheConfiguration());
        }
    }
}
