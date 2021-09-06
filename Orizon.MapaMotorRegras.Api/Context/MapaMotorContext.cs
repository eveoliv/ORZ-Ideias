using Microsoft.EntityFrameworkCore;
using Orizon.MapaMotorRegras.Api.Entities;

namespace Orizon.MapaMotorRegras.Api.Context
{
    public class MapaMotorContext : DbContext
    {
        public DbSet<RegraOperadora> RegrasOperadora { get; set; }
        public DbSet<RegraDetalhe> RegrasDetalhe { get; set; }
        public DbSet<RegraDocumentacao> RegrasDocumentacao { get; set; }

        public MapaMotorContext(DbContextOptions<MapaMotorContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RegraOperadoraConfiguration());
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RegraDetalheConfiguration());
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RegraDocumentacaoConfiguration());
        }
    }
}
