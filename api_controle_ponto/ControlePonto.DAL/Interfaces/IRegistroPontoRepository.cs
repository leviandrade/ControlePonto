using ControlePonto.Entity.Entities;

namespace ControlePonto.DAL.Interfaces
{
    public interface IRegistroPontoRepository : IBaseRepository<RegistroPontoEntity>
    {
        Task<List<RegistroPontoEntity>> Listar(string cpf, DateTime inicio, DateTime termino);
    }
}
