using ControlePonto.DAL.Context;
using ControlePonto.DAL.Interfaces;
using ControlePonto.Entity.Entities;

namespace ControlePonto.DAL.Repository
{
    public sealed class ColaboradorRepository : BaseRepository<ColaboradorEntity, ControlePontoContext>, IColaboradorRepository
    {
        public ColaboradorRepository(ControlePontoContext db) : base(db)
        {
        }

        public async Task<ColaboradorEntity> ObterPorCpf(string nrCpf)
        {
            var oRegistro = await Buscar(p => p.NrCpf.Equals(nrCpf));
            return oRegistro.FirstOrDefault();
        }

        public async Task<bool> PossuiCadastro(string nrCpf)
        {
            var oRegistro = await Buscar(p => p.NrCpf.Equals(nrCpf));
            return oRegistro.Any();
        }
    }
}
