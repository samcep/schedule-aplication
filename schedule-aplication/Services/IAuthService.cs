
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.IdentityModel.Tokens;
using schedule_aplication.DTO;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace schedule_aplication.Services
{
    public interface IAuthService
    {
        Task<IdentityResult> createNewUser(UserRegisterDto userRegisterDto);
    }

    public class AuthService : IAuthService
    {
   
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<AuthService> _logger;

        public AuthService(
            UserManager<IdentityUser> userManager,
            ILogger<AuthService> logger
        )
        {
            _userManager = userManager;
            _logger = logger;
        }
        public async Task<IdentityResult> createNewUser(UserRegisterDto userRegisterDto)
        {
            var user = new IdentityUser { UserName = userRegisterDto.UserName, Email = userRegisterDto.Email };
            IdentityResult result = await _userManager.CreateAsync(user, userRegisterDto.Password);
            return result;
        }

    }

}
