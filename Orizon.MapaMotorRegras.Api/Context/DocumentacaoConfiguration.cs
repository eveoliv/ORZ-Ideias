using Microsoft.EntityFrameworkCore;
using Orizon.MapaMotorRegras.Api.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Orizon.MapaMotorRegras.Api.Context
{
    internal class DocumentacaoConfiguration : IEntityTypeConfiguration<Documentacao>
    {
        public void Configure(EntityTypeBuilder<Documentacao> builder)
        {
            builder.ToTable("RegrasMotorDocumentacaoLinks");
            builder.Property(i => i.Codigo).HasColumnName("Codigo").HasColumnType("int").IsRequired();
            builder.Property(i => i.DocLink).HasColumnName("DocLink").HasColumnType("varchar(1000)").IsRequired();
        }
    }
}