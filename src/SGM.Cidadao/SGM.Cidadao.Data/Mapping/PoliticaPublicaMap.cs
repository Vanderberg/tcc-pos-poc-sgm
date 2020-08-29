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
            //builder.HasKey(p => )
        } 
    }
}