using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using schedule_aplication.CustomResponse;
using schedule_aplication.DTO;
using schedule_aplication.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace schedule_aplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IConfiguration _configuration;
        public AuthController(IAuthService authService, IConfiguration configuration)
        {
            _authService = authService;
            _configuration = configuration;

        }
        [HttpPost("/user-register")]
        public async Task<ActionResult<AuthResponse>> Register(UserRegisterDto userRegisterDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult identityResult = await _authService.createNewUser(userRegisterDto);
            if(identityResult.Succeeded)
            {
                return CreateToken(userRegisterDto);
            }else
            {
                var erros = identityResult.Errors;
              
                return BadRequest(erros);
            }
            
        }


        private AuthResponse CreateToken(UserRegisterDto userRegisterDto)
        {
            var claims = new List<Claim>()
            {
                new Claim("Email",userRegisterDto.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecretKey"]));

            var dateExpiration = DateTime.Now.AddDays(1);

            var credentianls = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var securityToken = new JwtSecurityToken(
                claims: claims,
                signingCredentials: credentianls,
                expires: dateExpiration
            );

            return new AuthResponse { Token = new JwtSecurityTokenHandler().WriteToken(securityToken), StatusCode = 200, DateExpiration = dateExpiration };
        }
    }
}
