using ControlePonto.Entity.Entities;

namespace ControlePonto.DAL.Interfaces
{
    public interface IColaboradorRepository : IBaseRepository<ColaboradorEntity>
    {
        Task<bool> PossuiCadastro(string nrCpf);
        Task<ColaboradorEntity> ObterPorCpf(string nrCpf);

    }
}
