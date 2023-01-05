using ControlePonto.DAL.Context;
using ControlePonto.DAL.Interfaces;
using ControlePonto.Entity.Entities;

namespace ControlePonto.DAL.Repository
{
    public sealed class UsuarioRepository : BaseRepository<UsuarioEntity, ControlePontoContext>, IUsuarioRepository
    {
        public UsuarioRepository(ControlePontoContext context) : base(context)
        {
        }

        public async Task<UsuarioEntity> Obter(string cpf, string senha)
        {
            var resultado = await Buscar(p => p.NrCpf.Equals(cpf) && p.Senha.Equals(senha));
            return resultado.FirstOrDefault();
        }
    }
}
