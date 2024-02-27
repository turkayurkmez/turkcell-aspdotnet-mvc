using eshop.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace eshop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }
        [HttpPost]
        public IActionResult Login(UserLoginViewModel userLogin)
        {
            if (ModelState.IsValid)
            {
                var user = userService.ValidateUser(userLogin.UserName, userLogin.Password);
                if (user != null)
                {
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("bu-cümle-bizim-için-kritik-bir-cümle"));
                    var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var claims = new Claim[]
                    {
                        new Claim(JwtRegisteredClaimNames.Name, user.UserName),
                        new Claim(ClaimTypes.Role,user.Role)

                    };

                    var token = new JwtSecurityToken(
                         issuer: "server.myapp",
                         audience: "client.myapp",
                         claims: claims,
                         notBefore: DateTime.Now,
                         expires: DateTime.Now.AddDays(2),
                         signingCredentials: credential);

                    return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
                }
                ModelState.AddModelError("failed", "hatalı kullanıcı adı veya şifre");
            }
            return BadRequest(ModelState);

        }
    }
}
