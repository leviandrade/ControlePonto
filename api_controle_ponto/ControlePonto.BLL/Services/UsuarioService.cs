using AutoMapper;
using ControlePonto.Entity.Services.Interfaces;
using ControlePonto.DAL.Interfaces;
using ControlePonto.DTO.DTOs;
using ControlePonto.Entity.Entities;
using ControlePonto.Helpers;
using ControlePonto.BLL.Validations;
using ControlePonto.Entity.Intefaces;

namespace ControlePonto.Entity.Services
{
    public sealed class UsuarioService : BaseService, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper, INotificador notificador) : base(notificador)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<UsuarioDTO> Obter(string cpf, string senha)
        {
            senha = CriptografiaHelper.Criptografar(senha);

            var oUsuario = await _usuarioRepository.Obter(cpf, senha);
            return _mapper.Map<UsuarioDTO>(oUsuario);
        }
        public async Task Adicionar(UsuarioDTO usuario)
        {
            var oUsuarioEntity = _mapper.Map<UsuarioEntity>(usuario, opt => opt.AfterMap((src, dest) =>
            {
                dest.CriptografarSenha();
            }));

            if (!ExecutarValidacao(new UsuarioValidation(), oUsuarioEntity)) return;

            _usuarioRepository.Adicionar(oUsuarioEntity);
            await _usuarioRepository.SaveChanges();
        }
    }
}
