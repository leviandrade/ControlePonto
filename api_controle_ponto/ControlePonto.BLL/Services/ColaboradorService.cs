using ControlePonto.Entity.Intefaces;
using ControlePonto.Entity.Services.Interfaces;
using ControlePonto.DAL.Interfaces;
using ControlePonto.Entity.Entities;
using ControlePonto.DTO.DTOs;
using AutoMapper;
using ControlePonto.BLL.Validations;

namespace ControlePonto.Entity.Services
{
    public sealed class ColaboradorService : BaseService, IColaboradorService
    {
        private readonly IColaboradorRepository _colaboradorRepository;
        private readonly IMapper _mapper;

        public ColaboradorService(
            IColaboradorRepository colaboradorRepository,
            IMapper mapper,
            INotificador notificador) : base(notificador)

        {
            _colaboradorRepository = colaboradorRepository;
            _mapper = mapper;
        }

        public async Task Adicionar(ColaboradorDTO colaborador)
        {
            var oColaboradorEntity = _mapper.Map<ColaboradorEntity>(colaborador);

            if (!ExecutarValidacao(new ColaboradorValidation(), oColaboradorEntity)) return;

            _colaboradorRepository.Adicionar(oColaboradorEntity);
            await _colaboradorRepository.SaveChanges();
        }
        public async Task Atualizar(ColaboradorDTO colaborador)
        {
            if (colaborador.Equals(0))
            {
                Notificar("Informe o Id do colaborador");
                return;            
            }

            var oColaboradorEntity = _mapper.Map<ColaboradorEntity>(colaborador);

            if (!ExecutarValidacao(new ColaboradorValidation(), oColaboradorEntity)) return;

            _colaboradorRepository.Atualizar(oColaboradorEntity);
            await _colaboradorRepository.SaveChanges();
        }

        public async Task<List<ColaboradorDTO>> Listar()
        {
            var lstColaboradorEntity = await _colaboradorRepository.Listar();
            return _mapper.Map<List<ColaboradorDTO>>(lstColaboradorEntity);
        }

        public async Task<ColaboradorDTO> ObterPorId(int id)
        {
            var oColaboradorEntity = await _colaboradorRepository.ObterPorId(id);
            return _mapper.Map<ColaboradorDTO>(oColaboradorEntity);
        }

        public Task<bool> PossuiCadastrado(string cpf)
        {
            return _colaboradorRepository.PossuiCadastro(cpf);
        }
    }
}
