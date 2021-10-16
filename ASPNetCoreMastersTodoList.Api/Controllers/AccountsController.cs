using ASPNetCoreMastersTodoList.Api.ApiModels;
using ASPNetCoreMastersTodoList.Api.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace ASPNetCoreMastersTodoList.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly JwtOptions _jwtOptions;

        public AccountsController(UserManager<IdentityUser> userManager,IOptions<JwtOptions> jwtOptions) { 
            _userManager = userManager;
            _jwtOptions = jwtOptions.Value;
        }
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(RegisterUserCommand command)
        {
            var user = new IdentityUser { UserName = command.Email, Email = command.Email };
            var result = await _userManager.CreateAsync(user, command.Password);
            if (result.Succeeded)
            {
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

                return Ok(new { code = code, email = command.Email });
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return BadRequest(ModelState);
            }
        }

        [HttpPost("confirm")]
        public async Task<IActionResult> ConfirmEmail(ConfirmBindingModel confirm)
        {
            var user = await _userManager.FindByEmailAsync(confirm.Email);
            var code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(confirm.Code));

            if (user == null || user.EmailConfirmed)
            {
                return BadRequest();
            } else if ((await _userManager.ConfirmEmailAsync(user, code)).Succeeded)
            {
                return Ok("Your email is confirmed");
            } else
            {
                return BadRequest();
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginBindingModel login)
        {
            IActionResult actionResult;
            var user = await _userManager.FindByEmailAsync(login.Email);
            if(user == null)
            {
                actionResult = NotFound(new { errors = new[] { $"User with email '{login.Email}' is not found."} });
            }  
            else if(await _userManager.CheckPasswordAsync(user,login.Password))
            {
                if(!user.EmailConfirmed)
                {
                    actionResult = BadRequest(new { errors = new[] { $"Email is not confirmed. Please go to your email and confirm it." } });
                }
                else
                {
                    var token = GenerateTokenAsync(user);
                    return Ok(new { jwt = token });
                }
            }
            else
            {
                actionResult = BadRequest(new { errors = new[] { $"Password is not valid." } });
            }
            return actionResult;
        }
        private async Task<string> GenerateTokenAsync(IdentityUser user)
        {
            IList<Claim> userClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var a = new JwtSecurityTokenHandler().WriteToken(new JwtSecurityToken(
              claims: userClaims,
              expires: DateTime.UtcNow.AddMonths(1),
              signingCredentials: new SigningCredentials(_jwtOptions.SecurityKey, SecurityAlgorithms.HmacSha256)
            ));
            return a;
        }
    }
}
