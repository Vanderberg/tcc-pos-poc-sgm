using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGM.Gestao.Domain.Entities;

namespace SGM.Gestao.Data.Mapping
{
    public class CandidatoVagaMap : IEntityTypeConfiguration<CandidatoVagaEntity>
    {
        public void Configure(EntityTypeBuilder<CandidatoVagaEntity> builder)
        {
            builder.ToTable("CandidatoVaga");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.StatusCandidato)
                .IsRequired();
        }
    }
}