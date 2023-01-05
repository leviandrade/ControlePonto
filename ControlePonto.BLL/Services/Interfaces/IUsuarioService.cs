using ControlePonto.DTO.DTOs;

namespace ControlePonto.BLL.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioDTO> Obter(string cpf, string senha);
    }
}
