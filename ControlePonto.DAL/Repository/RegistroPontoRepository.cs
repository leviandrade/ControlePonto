﻿using ControlePonto.DAL.Context;
using ControlePonto.DAL.Interfaces;
using ControlePonto.Entity.Entidades;

namespace ControlePonto.DAL.Repository
{
    public sealed class RegistroPontoRepository : BaseRepository<RegistroPontoEntity, ControlePontoContext>, IRegistroPontoRepository
    {
        public RegistroPontoRepository(ControlePontoContext context) : base(context)
        {
        }
    }
}
