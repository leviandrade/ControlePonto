using ControlePonto.Entity.Entidades;

namespace ControlePonto.BLL.Services.Interfaces
{
    public interface IColaboradorService
    {
        Task<ColaboradorEntity> ObterPorId(int id);
        Task<List<ColaboradorEntity>> Listar();
        Task Adicionar(ColaboradorEntity colaborador);
    }
}
