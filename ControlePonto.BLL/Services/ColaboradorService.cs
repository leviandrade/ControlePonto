using ControlePonto.BLL.Intefaces;
using ControlePonto.BLL.Services.Interfaces;
using ControlePonto.DAL.Interfaces;
using ControlePonto.Entity.Entities;

namespace ControlePonto.BLL.Services
{
    public sealed class ColaboradorService : BaseService, IColaboradorService
    {
        private readonly IColaboradorRepository _colaboradorRepository;

        public ColaboradorService(IColaboradorRepository colaboradorRepository,
                                             INotificador notificador) : base(notificador)

        {
            _colaboradorRepository = colaboradorRepository;
        }

        public Task Adicionar(ColaboradorEntity colaborador)
        {
            throw new NotImplementedException();
        }

        public Task<List<ColaboradorEntity>> Listar()
        {
            throw new NotImplementedException();
        }

        public Task<ColaboradorEntity> ObterPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
