using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGM.Cidadao.Domain.Entities;

namespace SGM.Cidadao.Data.Mapping
{
    public class CampanhaMap : IEntityTypeConfiguration<CampanhaEntity>
    {
        public void Configure(EntityTypeBuilder<CampanhaEntity> builder)
        {
            builder.ToTable("Campanha");
            builder.HasKey(c => c.Id);
            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasMaxLength(60);
            builder.Property(c => c.DataInicio)
                .IsRequired();
            builder.Property(c => c.DataFim)
                .IsRequired();
        }
    }
}