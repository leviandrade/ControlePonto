using ControlePonto.API.Configuration;
using ControlePonto.API.ViewModels;
using ControlePonto.Entity.Services.Interfaces;
using ControlePonto.DTO.DTOs;
using ControlePonto.Utils.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ControlePonto.Entity.Intefaces;

namespace ControlePonto.API.Controllers
{
    [Route("api/[controller]")]
    public class AutenticacaoController : BaseController
    {
        private readonly AppSettings _appSettings;
        private readonly IUsuarioService _usuarioService;

        public AutenticacaoController(IOptions<AppSettings> appSettings, IUsuarioService usuarioService, INotificador notificador) : base(notificador)
        {
            _appSettings = appSettings.Value;
            _usuarioService = usuarioService;
        }

        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            var oUsuario = await _usuarioService.Obter(login.Cpf, login.Senha);
            if(oUsuario is null)
            {
                NotificarErro("Usuário e/ou Senha Inválidos");
                return CustomResponse();
            }

            return CustomResponse(GerarJwt(oUsuario, login.Cpf));
        }

        private LoginResponseViewModel GerarJwt(UsuarioDTO usuario, string cpf)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.AuthenticationKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("CPF", cpf),
                    new Claim("ControlePonto", ((TipoUsuarioEnum)usuario.IdTipoUsuario).ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new LoginResponseViewModel
            {
                NmUsuario = usuario.NmUsuario,
                token = tokenHandler.WriteToken(token)
            };
        }
    }
}
