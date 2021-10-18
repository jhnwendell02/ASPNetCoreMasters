using ASPNetCoreMastersTodoList.Api.ApiModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreMastersTodoList.Api.Controllers
{
    [Route("{controller}")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AuthenticationSettings _settings;
        public UserController(IOptions<AuthenticationSettings> options)
        {
            _settings = options.Value;
        }

        [HttpGet] 
        public IActionResult Login()
        {
            return Ok(_settings.SecurityKey);
        }
    }
}
