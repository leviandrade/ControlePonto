using ControlePonto.Entity.Intefaces;
using ControlePonto.Entity.Services.Interfaces;
using ControlePonto.DAL.Interfaces;
using ControlePonto.Entity.Entities;
using AutoMapper;
using ControlePonto.BLL.Validations;
using ControlePonto.DTO.DTOs;

namespace ControlePonto.Entity.Services
{
    public sealed class RegistroPontoService : BaseService, IRegistroPontoService
    {
        private readonly IColaboradorRepository _colaboradorRepository;
        private readonly IRegistroPontoRepository _registroPontoRepository;
        private readonly IMapper _mapper;

        public RegistroPontoService(
            IColaboradorRepository colaboradorRepository,
            IRegistroPontoRepository registroPontoRepository,
            IMapper mapper,
            INotificador notificador) : base(notificador)
        {
            _colaboradorRepository = colaboradorRepository;
            _registroPontoRepository = registroPontoRepository;
            _mapper = mapper;
        }

        public async Task Adicionar(RegistroPontoDTO registroPonto)
        {

            var oColaborador = await _colaboradorRepository.ObterPorCpf(registroPonto.CPF);

            var oRegistroPontoEntity = new RegistroPontoEntity
            {
                IdColaborador = oColaborador.Id,
                DtRegistroPonto = DateTime.Now,
                Imagem = registroPonto.Imagem,
                Latitude = registroPonto.Latitude,
                Longitude = registroPonto.Longitude
            };

            if (!ExecutarValidacao(new RegistroPontoValidation(), oRegistroPontoEntity)) return;

            _registroPontoRepository.Adicionar(oRegistroPontoEntity);
            await _registroPontoRepository.SaveChanges();
        }

        public async Task<List<RegistroPontoDTO>> Listar()
        {
            var lstRegistroPontoEntity = await _registroPontoRepository.Listar();
            return _mapper.Map<List<RegistroPontoDTO>>(lstRegistroPontoEntity);
        }

        public async Task<List<RegistroPontoDTO>> Listar(string cpf, DateTime inicio, DateTime termino)
        {
            var lstRegistroPontoEntity = await _registroPontoRepository.Listar(cpf, inicio, termino);
            return _mapper.Map<List<RegistroPontoDTO>>(lstRegistroPontoEntity);
        }

        public async Task<RegistroPontoDTO> ObterPorId(int id)
        {
            var oRegistroPontoEntity = await _registroPontoRepository.ObterPorId(id);
            return _mapper.Map<RegistroPontoDTO>(oRegistroPontoEntity);
        }
    }
}
