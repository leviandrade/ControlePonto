using ControlePonto.Entity.Intefaces;
using ControlePonto.Entity.Notificacoes;
using ControlePonto.Entity.Services;
using ControlePonto.Entity.Services.Interfaces;
using ControlePonto.DAL.Interfaces;
using ControlePonto.DAL.Repository;

namespace ControlePonto.API.Configuration
{
    public static class InjectionDependencyCore
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<INotificador, Notificador>();
            AddBLL(services);
            AddDAL(services);
        }
        private static void AddBLL(IServiceCollection services)
        {
            services.AddScoped<IColaboradorService, ColaboradorService>();
            services.AddScoped<IRegistroPontoService, RegistroPontoService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
        }
        private static void AddDAL(IServiceCollection services)
        {
            services.AddScoped<IColaboradorRepository, ColaboradorRepository>();
            services.AddScoped<IRegistroPontoRepository, RegistroPontoRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

        }
    }
}
