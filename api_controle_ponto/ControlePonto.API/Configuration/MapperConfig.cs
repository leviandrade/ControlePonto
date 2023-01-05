using AutoMapper;
using ControlePonto.DTO.DTOs;
using ControlePonto.Entity.Entities;

namespace ControlePonto.API.Configuration
{
    public class MapperConfig
    {
        public static IMapper RegisterMappers()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ColaboradorEntity, ColaboradorDTO>().ReverseMap();
                cfg.CreateMap<RegistroPontoEntity, RegistroPontoDTO>().ReverseMap();
                cfg.CreateMap<UsuarioEntity, UsuarioDTO>().ReverseMap();
            });

            return config.CreateMapper();
        }
    }
}