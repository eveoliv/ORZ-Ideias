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
            builder.Property(o => o.Operadora).HasColumnType("int").IsRequired();
            builder.Property(n => n.Nome).HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(m => m.Regras).HasColumnType("nvarchar(max)").IsRequired();           
        }
    }
}