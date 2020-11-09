using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGM.Gestao.Domain.Entities;

namespace SGM.Gestao.Data.Mapping
{
    public class VagaMap : IEntityTypeConfiguration<VagaEntity>
    {
        public void Configure(EntityTypeBuilder<VagaEntity> builder)
        {
            builder.ToTable("Vaga");
            builder.HasKey(c => c.Id);
            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasMaxLength(60);
            builder.Property(c => c.DataInicio)
                .IsRequired();
        }
    }
}