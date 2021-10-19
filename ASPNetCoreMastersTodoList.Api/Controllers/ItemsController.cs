using ASPNetCoreMastersTodoList.Api.ApiModels;
using ASPNetCoreMastersTodoList.Api.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace ASPNetCoreMastersTodoList.Api.Controllers
{
    [Route("{controller}")]
    [ApiController]
    [EnsureItemIdExistFilterAttribute]
    [Authorize]
    public class ItemsController : ControllerBase
    {
        public readonly IItemService _service;
        private readonly UserManager<IdentityUser> _userService;
        private readonly IAuthorizationService _authService;
        private readonly ILogger<ItemsController> _logger;
        public ItemsController(IItemService service, UserManager<IdentityUser> userService, IAuthorizationService authService, ILogger<ItemsController> logger)
        {
            _service = service;
            _userService = userService;
            _authService = authService;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }
        [HttpGet("{itemId}")]
        public IActionResult Get(int itemId)
        {
            return Ok(_service.Get(itemId));
        }
        [HttpGet("filterBy")]
        public IActionResult GetByFilters([FromQuery] Dictionary<string, string> filters)
        {
            var textValues = filters["text"];
            return Ok(_service.GetAllByFilter(new ItemByFilterDTO() { text = textValues }));
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] ItemCreateBindingModel itemCreateModel)
        {
            var email = ((ClaimsIdentity)User.Identity).Name;
            ItemDTO requestData = new ItemDTO() { ItemId = itemCreateModel.ItemId, Text = itemCreateModel.Name };
            _service.Create(requestData);
            return Ok(requestData);
        }
        [HttpPut("{itemId}")]
        public async Task<IActionResult> PutAsync(int itemId, [FromBody] ItemUpdateBindingModel itemUpdateModel)
        {
            var itemVM = _service.Get(itemUpdateModel.ItemId);
            var authResult = await _authService.AuthorizeAsync(User, new ItemDTO() { CreatedBy = itemVM.CreatedBy }, "CanEditItems");
            if (!authResult.Succeeded)
            {
                return new ForbidResult();
            }
            ItemDTO requestData = new ItemDTO() { ItemId = itemUpdateModel.ItemId, Text = itemUpdateModel.Name };
            _service.Update(requestData);
            return Ok(requestData);
        }
        [HttpDelete("{itemId}")]
        public IActionResult Delete(int itemId)
        {
            return Ok(_service.Delete(itemId));
        }
    }
}
