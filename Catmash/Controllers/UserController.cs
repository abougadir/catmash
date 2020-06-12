using Catmash.Models;
using Catmash.Utils;
using Catmash.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Catmash.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public UserController(
            UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            await this.signInManager.SignOutAsync();
            
            return Ok();
        }

        [HttpPost("subscribe")]
        public async Task<IActionResult> Subscribe([FromBody] UserVM user)
        {
            if (!ModelState.IsValid)
                return BadRequest("Données invalides");

            user.User.UserName = user.User.Email;

            var result = await this.userManager.CreateAsync(user.User, user.Password);

            if (result.Succeeded)
                return Ok();

            return BadRequest("Erreur dans la création de l'utilisateur : " + string.Join(",", result.Errors.Select(error => error.Description)));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginVM user)
        {
            if (!ModelState.IsValid)
                return BadRequest("Données invalides");

            var result = await this.signInManager.PasswordSignInAsync(
                user.Email,
                user.Password,
                isPersistent: false,
                lockoutOnFailure: false
            );
            
            if (result.Succeeded)
                return Ok(new LoginResponseVM
                {
                    AccessToken = this.GenerateToken(user.Email)
                });

            return BadRequest("Erreur dans la création de l'utilisateur");
        }

        private string GenerateToken(string email)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Constant.API_KEY_VALUE);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, email)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
