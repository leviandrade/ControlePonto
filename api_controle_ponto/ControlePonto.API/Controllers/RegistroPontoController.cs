using ControlePonto.DTO.DTOs;
using ControlePonto.Entity.Intefaces;
using ControlePonto.Entity.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControlePonto.API.Controllers
{
    [Route("api/[controller]")]
    public class RegistroPontoController : BaseController
    {
        private readonly IRegistroPontoService _registroPontoService;

        public RegistroPontoController(IRegistroPontoService registroPontoService, INotificador notificador) : base(notificador)
        {
            _registroPontoService = registroPontoService;
        }

        [HttpPost]
        public async Task<IActionResult> post([FromBody] RegistroPontoDTO registroPonto)
        {
            try
            {
                await _registroPontoService.Adicionar(registroPonto);
            }
            catch (Exception e)
            {

            }
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

        [HttpGet("{cpf}/{inicio}/{termino}")]
        public async Task<IActionResult> get(string cpf, DateTime inicio, DateTime termino)
        {
            return CustomResponse(await _registroPontoService.Listar(cpf, inicio, termino));
        }
    }
}
