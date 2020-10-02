using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGM.Cidadao.Domain.Entities;

namespace SGM.Cidadao.Data.Mapping
{
    public class VotacaoMap : IEntityTypeConfiguration<VotacaoEntity>
    {
        public void Configure(EntityTypeBuilder<VotacaoEntity> builder)
        {
            builder.ToTable("Votacao");
            builder.HasKey(c => c.Id);
        }
    }
}