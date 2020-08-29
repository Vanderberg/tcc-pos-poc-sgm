using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGM.Cidadao.Domain.Entities;

namespace SGM.Cidadao.Data.Mapping
{
    public class PoliticaPublicaMap : IEntityTypeConfiguration<PoliticaPublica>
    {
        public void Configure(EntityTypeBuilder<PoliticaPublica> builder)
        {
            builder.ToTable("PolicaPublica");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Titulo)
                .IsRequired()
                .HasMaxLength(60);
            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasMaxLength(1000);
            builder.Property(p => p.DescricaoArea)
                .IsRequired();
            builder.Property(p => p.OrcamentoPrevisto)
                .IsRequired();
            builder.Property(p => p.OrcamentoRealizado);
            builder.Property(p => p.NomeResponsavel)
                .IsRequired();

        } 
    }
}
