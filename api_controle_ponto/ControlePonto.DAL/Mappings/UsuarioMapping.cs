using ControlePonto.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControlePonto.DAL.Mappings
{
    internal class UsuarioMapping : IEntityTypeConfiguration<UsuarioEntity>
    {
        public void Configure(EntityTypeBuilder<UsuarioEntity> builder)
        {
            builder.ToTable("TB_USUARIO");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("ID_USUARIO");
            builder.Property(p => p.NmUsuario).HasColumnName("NM_USUARIO");
            builder.Property(p => p.NrCpf).HasColumnName("NR_CPF");
            builder.Property(p => p.Senha).HasColumnName("SENHA");
            builder.Property(p => p.IdTipoUsuario).HasColumnName("ID_TIPO_USUARIO");
        }
    }
}
