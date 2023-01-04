using ControlePonto.Entity.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControlePonto.DAL.Mappings
{
    internal class RegistroPontoMapping : IEntityTypeConfiguration<RegistroPontoEntity>
    {
        public void Configure(EntityTypeBuilder<RegistroPontoEntity> builder)
        {
            builder.ToTable("TB_REGISTRO_PONTO");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("ID_REGISTRO_PONTO");
            builder.Property(p => p.IdColaborador).HasColumnName("ID_COLABORADOR");
            builder.Property(p => p.DtRegistroPonto).HasColumnName("DT_REGISTRO_PONTO");
        }
    }
}
