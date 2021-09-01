using Microsoft.EntityFrameworkCore;
using Orizon.MapaMotorRegras.Api.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Orizon.MapaMotorRegras.Api.Context
{
    internal class RegraDetalheConfiguration : IEntityTypeConfiguration<RegraDetalhe>
    {
        public void Configure(EntityTypeBuilder<RegraDetalhe> builder)
        {
            builder.ToTable("criticasdeanalise");

            builder.Property(i => i.Codigo).HasColumnName("codigo").HasColumnType("int").IsRequired();
            builder.Property(i => i.Texto_analise).HasColumnName("texto_analise").HasColumnType("varchar(350)");
            builder.Property(i => i.Operacao).HasColumnName("operacao").HasColumnType("varchar(350)");
            builder.Property(i => i.Aut_fat).HasColumnName("aut_fat").HasColumnType("varchar(350)");
            builder.Property(i => i.Nivel).HasColumnName("nivel").HasColumnType("varchar(350)");
            builder.Property(i => i.Descricao).HasColumnName("descricao").HasColumnType("varchar(350)");
            builder.Property<byte>(i => i.Alteravel).HasColumnName("alteravel");
            builder.Property(i => i.Link).HasColumnName("ID_LINK").HasColumnType("int").IsRequired();
            builder.Property(i => i.Detalhes).HasColumnName("DETALHES").HasColumnType("varchar(1000)");
        }
    }
}