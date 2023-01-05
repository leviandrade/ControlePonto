using ControlePonto.DTO.DTOs;
using ControlePonto.Entity.Intefaces;
using ControlePonto.Entity.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControlePonto.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class RegistroPontoController : BaseController
    {
        private readonly IRegistroPontoService _registroPontoService;

        public RegistroPontoController(IRegistroPontoService registroPontoService, INotificador notificador) : base(notificador)
        {
            _registroPontoService = registroPontoService;
        }

        [HttpPost]
        public async Task<IActionResult> post(RegistroPontoDTO registroPonto)
        {
            await _registroPontoService.Adicionar(registroPonto);
            return CustomResponse();
        }

        [HttpGet]
        public async Task<IActionResult> get()
        {
            return CustomResponse(await _registroPontoService.Listar());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> get(int id)
        {
            return CustomResponse(await _registroPontoService.ObterPorId(id));
        }
    }
}
