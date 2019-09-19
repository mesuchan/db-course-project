using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CourseProject.Controllers
{
    public 
        class LoginPassword
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }

    [Route("api/auth")]
    public class AuthController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;

        public AuthController(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }

        [HttpPost]
        public async Task<ActionResult> Auth([FromBody] LoginPassword loginPassword)
        {
            var user = await userManager.FindByNameAsync(loginPassword.Login);

            if (user is null)
                return Unauthorized();

            if (!await userManager.CheckPasswordAsync(user, loginPassword.Password))
                return Unauthorized();

            return Ok(new
            {
                AccessToken = GenerateAccessToken(loginPassword.Login)
            });
        }

        [HttpPost("register")]
        public async Task<ActionResult> Reg([FromBody] LoginPassword loginPassword)
        {
            var user = await userManager.FindByNameAsync(loginPassword.Login);

            if (user != null)
                return BadRequest();

            var res = await userManager.CreateAsync(new IdentityUser(loginPassword.Login), loginPassword.Password);

            if (!res.Succeeded)
                return BadRequest();

            return Ok();
        }

        private string GenerateAccessToken(string userName)
        {
            var claims = new Claim[]
            {
                new Claim("user", userName)
            };

            var jwt = new JwtSecurityToken(
                claims: claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes("burnburnburnburn")),
                    SecurityAlgorithms.HmacSha256
                )
            );

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
