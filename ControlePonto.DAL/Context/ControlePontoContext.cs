using ControlePonto.DAL.Interfaces;
using ControlePonto.DAL.Mappings;
using ControlePonto.Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace ControlePonto.DAL.Context
{
    public sealed class ControlePontoContext : DbContext, IUnitOfWork<ControlePontoContext>
    {
        public ControlePontoContext(DbContextOptions<ControlePontoContext> options) : base(options)
        {

        }

        public DbSet<ColaboradorEntity> Colaborador { get; set; }
        public DbSet<RegistroPontoEntity> RegistroPonto { get; set; }
        public DbSet<UsuarioEntity> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ColaboradorMapping());
            modelBuilder.ApplyConfiguration(new RegistroPontoMapping());
            modelBuilder.ApplyConfiguration(new UsuarioMapping());

            base.OnModelCreating(modelBuilder);
        }
        public async Task CommitAsync()
        {
            await SaveChangesAsync();
        }
    }
}
