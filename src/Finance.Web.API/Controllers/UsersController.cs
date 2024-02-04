using Finance.Domain.Entity.Entities.Users.Identity;
using Finance.Web.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;

namespace Finance.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public UsersController(
                UserManager<ApplicationUser> userManager,
                SignInManager<ApplicationUser> signInManager
            )
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/api/AddUser")]
        public async Task<IActionResult> AddUser([FromBody] Login login)
        {
            if (
                string.IsNullOrWhiteSpace(login.Name) ||
                string.IsNullOrWhiteSpace(login.Email) ||
                string.IsNullOrWhiteSpace(login.Password))

            {
                return Ok("Faltam aguns dados, por favar verifique");
            }

            var user = new ApplicationUser
            {
                Name = login.Name,
                Email = login.Email,
                UserName = login.Email
            };

            var result = await userManager.CreateAsync(user, login.Password);

            if (result.Errors.Any())
            {
                return Ok(result.Errors);
            }

            // Geração da confirmação caso precise

            var code = await userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

            //Rertorno do Email
            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));

            var resposeReturn = await userManager.ConfirmEmailAsync(user, code);

            if (resposeReturn.Succeeded)
            {
                return Ok("Usuário adicionado com sucesso!");
            }
            else
            {
                return Ok("Ocorreu um erro ao adiciomar o usuário!");
            }
        }

        [HttpPut("/api/UpdateUser/{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] Login login)
        {
            if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(login.Name) || string.IsNullOrWhiteSpace(login.Email) || string.IsNullOrWhiteSpace(login.Password))
            {
                return BadRequest("Faltam alguns dados!");
            }

            var user = await userManager.FindByIdAsync(id);

            if (user == null)
            {
                return BadRequest("Usuário não encontrado!");
            }

            // Atualiza os dados do usuário
            user.Name = login.Name; // não pode alterar


            // Atualiza a senha se fornecida
            //if (!string.IsNullOrWhiteSpace(login.senha))
            //{
            //    var newPasswordHash = _userManager.PasswordHasher.HashPassword(user, login.senha);
            //    user.PasswordHash = newPasswordHash;
            //}

            var result = await userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return Ok("Usuário atualizado com sucesso!");
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        [HttpDelete("/api/DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return BadRequest("ID do usuáio não fornceido!");
            }

            var user = await userManager.FindByIdAsync(id);
            if (user == null)
            {
                return BadRequest("Usuário não encontrado!");
            }

            var result = await userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return Ok("Usuário deletado com sucesso!");
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        [HttpGet("/api/UserList")]
        public IActionResult UserList()
        {

            var users = userManager.Users.ToList();

            // Você pode mapear os cados do usuário para um modelo mais simples se necessário

            var simplefiedUserList = users.Select(us => new
            {
                UserId = us.Id,
                Name = us.Name,
                Email = us.Email,

                //Adicione mais campos caso necessário
            });
            return Ok(simplefiedUserList);
        }
    }
}
