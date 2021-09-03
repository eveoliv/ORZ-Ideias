using Microsoft.EntityFrameworkCore;
using Orizon.MapaMotorRegras.Api.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Orizon.MapaMotorRegras.Api.Context
{
    internal class RegraOperadoraConfiguration : IEntityTypeConfiguration<RegraOperadora>
    {
        public void Configure(EntityTypeBuilder<RegraOperadora> builder)
        {
            builder.ToTable("MapaMotorRegras");
            builder.Property(o => o.Operadora).HasColumnType("nvarchar(100)").IsRequired();
            builder.Property(m => m.Regras).HasColumnType("nvarchar(max)").IsRequired();           
        }
    }
}