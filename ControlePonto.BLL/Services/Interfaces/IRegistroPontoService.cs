using ControlePonto.Entity.Entidades;

namespace ControlePonto.BLL.Services.Interfaces
{
    public interface IRegistroPontoService
    {
        Task<RegistroPontoEntity> ObterPorId(int id);
        Task<List<RegistroPontoEntity>> Listar();
        Task Adicionar(RegistroPontoEntity registroPonto);
    }
}
