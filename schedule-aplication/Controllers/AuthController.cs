using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using schedule_aplication.DTO;

namespace schedule_aplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        public AuthController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public ActionResult Register(UserRegisterDto userRegisterDto)
        {
            return NoContent();
        }
    }
}
