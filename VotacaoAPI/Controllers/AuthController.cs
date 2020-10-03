using Business.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;
using VotacaoAPI.Extensions;
using VotacaoAPI.ViewModels;

namespace VotacaoAPI.Controllers
{
    [Route("api")]
    public class AuthController : MainController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly AppSettings _appSerings;

        public AuthController(INotificador notificador,
                              UserManager<ApplicationUser> userManager,
                              SignInManager<ApplicationUser> signInManag,
                              IOptions<AppSettings> appSerings) : base(notificador)
        {
            _signInManager = signInManag;
            _userManager = userManager;
            _appSerings = appSerings.Value;
        }

        [HttpPost("nova-conta")]
        public async Task<ActionResult> Registrar(RegisterUserViewModel registerUser)
        {
            if (!ModelState.IsValid) return CustomeResponse(ModelState);
            var user = new ApplicationUser { UserName = registerUser.Email, Email = registerUser.Email, NomeCompleto = registerUser.Nome, EmailConfirmed = true };
            var result = await _userManager.CreateAsync(user, registerUser.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return CustomeResponse(GerarJwt());
            }
            foreach (var erro in result.Errors)
            {
                NotificarErro(erro.Description);
            }
            return CustomeResponse(registerUser);
        }

        [HttpPost("entrar")]
        public async Task<ActionResult> Logar(LoginUserViewModel loginUser)
        {
            if (!ModelState.IsValid) return CustomeResponse(ModelState);

            var result = await _signInManager.PasswordSignInAsync(loginUser.Email, loginUser.Password, false, true);

            if (result.Succeeded)
            {
                return CustomeResponse(GerarJwt());
            }
            if (result.IsLockedOut)
            {
                NotificarErro("Usuário temporariamente bloqueado por tentativas inválidas");
                return CustomeResponse(loginUser);
            }

            NotificarErro("Usuário ou Senha incorretos");
            return CustomeResponse(loginUser);
        }
        private string GerarJwt()
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSerings.Secret);
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _appSerings.Emissor,
                Audience = _appSerings.ValidoEm,
                Expires = DateTime.UtcNow.AddHours(_appSerings.ExpiracaoHoras),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature)
            });
            var encodedToken = tokenHandler.WriteToken(token);
            return encodedToken;
        }
    }
}