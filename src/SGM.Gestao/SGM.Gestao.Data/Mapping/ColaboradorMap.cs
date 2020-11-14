using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGM.Gestao.Domain.Entities;

namespace SGM.Gestao.Data.Mapping
{
    public class ColaboradorMap : IEntityTypeConfiguration<ColaboradorEntity>
    {
        public void Configure(EntityTypeBuilder<ColaboradorEntity> builder)
        {
            builder.ToTable("Colaborador");
            builder.HasKey(c => c.Id);
            builder.Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(60);
            builder.Property(p => p.Sobrenome)
                .IsRequired()
                .HasMaxLength(60);
            builder.Property(c => c.CPF)
                .IsRequired()
                .HasMaxLength(11);
        }
    }
}