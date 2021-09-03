using Microsoft.EntityFrameworkCore;
using Orizon.MapaMotorRegras.Api.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Orizon.MapaMotorRegras.Api.Context
{
    internal class RegraDocumentacaoConfiguration : IEntityTypeConfiguration<RegraDocumentacao>
    {
        public void Configure(EntityTypeBuilder<RegraDocumentacao> builder)
        {
            builder.ToTable("RegrasMotorDocumentacaoLinks");
            builder.Property(i => i.Codigo).HasColumnName("Codigo").HasColumnType("int").IsRequired();
            builder.Property(i => i.DocLink).HasColumnName("DocLink").HasColumnType("varchar(1000)").IsRequired();
        }
    }
}