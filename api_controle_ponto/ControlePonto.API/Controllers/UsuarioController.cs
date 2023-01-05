using ControlePonto.Entity.Services.Interfaces;
using ControlePonto.DTO.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ControlePonto.Entity.Intefaces;

namespace ControlePonto.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class UsuarioController : BaseController
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService, INotificador notificador) : base(notificador)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public async Task<IActionResult> post(UsuarioDTO usuario)
        {
            await _usuarioService.Adicionar(usuario);
            return CustomResponse();
        }
    }
}
