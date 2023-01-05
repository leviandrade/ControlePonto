using ControlePonto.Entity.Entities;

namespace ControlePonto.DAL.Interfaces
{
    public interface IUsuarioRepository : IBaseRepository<UsuarioEntity>
    {
        Task<UsuarioEntity> Obter(string cpf, string senha);
    }
}
