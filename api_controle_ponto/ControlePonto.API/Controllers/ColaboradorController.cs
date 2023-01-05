using ControlePonto.DTO.DTOs;
using ControlePonto.Entity.Intefaces;
using ControlePonto.Entity.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControlePonto.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class ColaboradorController : BaseController
    {
        private readonly IColaboradorService _colaboradorService;

        public ColaboradorController(IColaboradorService colaboradorService, INotificador notificador) : base(notificador)
        {
            _colaboradorService = colaboradorService;
        }

        [HttpPost]
        public async Task<IActionResult> post(ColaboradorDTO colaborador)
        {
            await _colaboradorService.Adicionar(colaborador);
            return CustomResponse();
        }
        [HttpPut]
        public async Task<IActionResult> put(ColaboradorDTO colaborador)
        {
            await _colaboradorService.Atualizar(colaborador);
            return CustomResponse();
        }

        [HttpGet]
        public async Task<IActionResult> get()
        {
            return CustomResponse(await _colaboradorService.Listar());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> get(int id)
        {
            return CustomResponse(await _colaboradorService.ObterPorId(id));
        }
    }
}
