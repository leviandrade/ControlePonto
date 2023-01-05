using ControlePonto.DAL.Context;
using ControlePonto.DAL.Interfaces;
using ControlePonto.Entity.Entities;

namespace ControlePonto.DAL.Repository
{
    public sealed class ColaboradorRepository : BaseRepository<ColaboradorEntity, ControlePontoContext>, IColaboradorRepository
    {
        public ColaboradorRepository(ControlePontoContext context) : base(context)
        {
        }
    }
}
