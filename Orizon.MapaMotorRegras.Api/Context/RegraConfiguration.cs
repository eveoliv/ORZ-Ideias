using Microsoft.EntityFrameworkCore;
using Orizon.MapaMotorRegras.Api.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Orizon.MapaMotorRegras.Api.Context
{
    internal class RegraConfiguration : IEntityTypeConfiguration<Regra>
    {
        public void Configure(EntityTypeBuilder<Regra> builder)
        {
            builder.Property(o => o.Opereadora).HasColumnType("nvarchar(100)").IsRequired();

            builder.Property(m => m.Mapa).HasColumnType("nvarchar(max)");
        }
    }
}