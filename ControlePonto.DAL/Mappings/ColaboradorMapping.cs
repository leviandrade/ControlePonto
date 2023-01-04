using ControlePonto.Entity.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControlePonto.DAL.Mappings
{
    internal sealed class ColaboradorMapping : IEntityTypeConfiguration<ColaboradorEntity>
    {
        public void Configure(EntityTypeBuilder<ColaboradorEntity> builder)
        {
            builder.ToTable("TB_COLABORADOR");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("ID_COLABORADOR");
            builder.Property(p => p.NmColaborador).HasColumnName("NM_COLABORADOR");
            builder.Property(p => p.NrCpf).HasColumnName("NR_CPF");
        }
    }
}
