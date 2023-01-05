using ControlePonto.DTO.DTOs;

namespace ControlePonto.Entity.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioDTO> Obter(string cpf, string senha);
        Task Adicionar(UsuarioDTO usuario);
    }
}
