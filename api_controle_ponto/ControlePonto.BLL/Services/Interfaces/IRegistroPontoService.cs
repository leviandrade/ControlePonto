using ControlePonto.DTO.DTOs;

namespace ControlePonto.Entity.Services.Interfaces
{
    public interface IRegistroPontoService
    {
        Task<RegistroPontoDTO> ObterPorId(int id);
        Task<List<RegistroPontoDTO>> Listar(string cpf, DateTime inicio, DateTime termino);
        Task<List<RegistroPontoDTO>> Listar();
        Task Adicionar(RegistroPontoDTO registroPonto);
    }
}
