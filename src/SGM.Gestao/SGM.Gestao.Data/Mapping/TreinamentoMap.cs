using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGM.Gestao.Domain.Entities;

namespace SGM.Gestao.Data.Mapping
{
    public class TreinamentoMap : IEntityTypeConfiguration<TreinamentoEntity>
    {
        public void Configure(EntityTypeBuilder<TreinamentoEntity> builder)
        {
            builder.ToTable("Treinamento");
            builder.HasKey(c => c.Id);
            builder.Property(p => p.Objetivo)
                .IsRequired()
                .HasMaxLength(250);
            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasMaxLength(60);
            builder.Property(p => p.Cronogrmana)
                .IsRequired()
                .HasColumnType("blob");
            builder.Property(c => c.DataInicio)
                .IsRequired();
        }
    }
}