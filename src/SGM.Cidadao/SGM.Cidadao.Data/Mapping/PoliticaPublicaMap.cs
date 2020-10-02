using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGM.Cidadao.Domain.Entities;

namespace SGM.Cidadao.Data.Mapping
{
    public class PoliticaPublicaMap : IEntityTypeConfiguration<PoliticaPublicaEntity>
    {
        public void Configure(EntityTypeBuilder<PoliticaPublicaEntity> builder)
        {
            builder.ToTable("PoliticaPublica");
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
            builder.Property(p => p.NomeResponsavel)
                .IsRequired()
                .HasMaxLength(60);

        } 
    }
}
