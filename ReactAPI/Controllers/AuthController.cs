using ReactAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReactAPI.Models.Interfaces;

namespace ReactAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        readonly IAuthService authService;
        DataContext db = new DataContext();

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost("LoginUser")]
        public async Task<ActionResult<UserLoginResponse>> LoginUserAsync([FromBody] UserLoginRequest request)
        {
            var result = await authService.LoginUserAsync(request);

            return result;
        }

        [HttpPost("/registerUser")]
        [AllowAnonymous]
        public async Task<ActionResult<Boolean>> RegisterUserAsync([FromBody] UserRegisterRequest request)
        {
            User newUser = new User();
            var user = db.User.FirstOrDefault(x => x.Name == request.Username);
            if (user == null)
            {
                newUser.Name = request.Username;
                newUser.Password = request.Password;
                newUser.Email = request.Email;
                db.User.Add(newUser);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
