using AutoMapper;
using ControlePonto.BLL.Services.Interfaces;
using ControlePonto.DAL.Interfaces;
using ControlePonto.DTO.DTOs;

namespace ControlePonto.BLL.Services
{
    public sealed class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<UsuarioDTO> Obter(string cpf, string senha)
        {
            var oUsuario = await _usuarioRepository.Obter(cpf, senha);
            return _mapper.Map<UsuarioDTO>(oUsuario);
        }
    }
}
