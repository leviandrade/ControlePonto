using ControlePonto.DAL.Context;
using ControlePonto.DAL.Interfaces;
using ControlePonto.Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace ControlePonto.DAL.Repository
{
    public sealed class RegistroPontoRepository : BaseRepository<RegistroPontoEntity, ControlePontoContext>, IRegistroPontoRepository
    {
        public RegistroPontoRepository(ControlePontoContext context) : base(context)
        {
        }
        public async Task<List<RegistroPontoEntity>> Listar(string cpf, DateTime inicio, DateTime termino)
        {
            return await Db.RegistroPonto
                           .Include(p => p.Colaborador)
                           .Where(p => p.Colaborador.NrCpf.Equals(cpf) &&
                                     p.DtRegistroPonto >= inicio &&
                                     p.DtRegistroPonto.Date <= termino)
                           .ToListAsync();
        }
    }
}
