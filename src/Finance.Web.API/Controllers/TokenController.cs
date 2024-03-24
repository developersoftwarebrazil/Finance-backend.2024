using Finance.Domain.Entity.Entities.Users.Identity;
using Finance.Web.API.Models;
using Finance.Web.API.Tokens;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public TokenController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager
            )
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }


        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/api/CreateToken")]
        public async Task<IActionResult> CreateToken([FromBody] InputModel Input)
        {
            if (string.IsNullOrWhiteSpace(Input.Email) || string.IsNullOrWhiteSpace(Input.Password))
            {
                return Unauthorized();
            }

            var result = await signInManager.PasswordSignInAsync(Input.Email, Input.Password, false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                var token = new TokenJWTBuilder()
                 .AddSecurityKey(JwtSecurityKey.Create("This_is_my_special_Secret_Key-12345678"))
                 .AddSubject("Aplicação para controle financeiro 2024")
                 .AddIssuer("Teste.Security.Bearer")
                 .AddAudience("Teste.Security.Bearer")
                 .AddClaim("APIUserFinanceSystem", "1")
                 .AddExpiry(5)
                 .Builder();

                return Ok(token.value);

            }
            else
            {
                return Unauthorized();
            }

        }
    }
}
