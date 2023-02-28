using ControlePonto.DTO.DTOs;

namespace ControlePonto.Entity.Services.Interfaces
{
    public interface IColaboradorService
    {
        Task<ColaboradorDTO> ObterPorId(int id);
        Task<List<ColaboradorDTO>> Listar();
        Task Adicionar(ColaboradorDTO colaborador);
        Task Atualizar(ColaboradorDTO colaborador);
        Task<bool> PossuiCadastrado(string cpf);
    }
}
