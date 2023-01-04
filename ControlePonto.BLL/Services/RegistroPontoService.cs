using ControlePonto.BLL.Intefaces;
using ControlePonto.BLL.Services.Interfaces;
using ControlePonto.DAL.Interfaces;
using ControlePonto.Entity.Entidades;

namespace ControlePonto.BLL.Services
{
    public sealed class RegistroPontoService : BaseService, IRegistroPontoService
    {
        private readonly IRegistroPontoRepository _registroPontoRepository;

        public RegistroPontoService(IRegistroPontoRepository registroPontoRepository,
                                             INotificador notificador) : base(notificador)
        {
            _registroPontoRepository = registroPontoRepository;
        }

        public Task Adicionar(RegistroPontoEntity registroPonto)
        {
            throw new NotImplementedException();
        }

        public Task<List<RegistroPontoEntity>> Listar()
        {
            throw new NotImplementedException();
        }

        public Task<RegistroPontoEntity> ObterPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
