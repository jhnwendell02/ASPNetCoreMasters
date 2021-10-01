using ASPNetCoreMastersTodoList.Api.ApiModels;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ASPNetCoreMastersTodoList.Api.Controllers
{
    [Route("{controller}")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        public readonly IItemService _service;
        public ItemsController(IItemService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult GetAll(int userId)
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
        public IActionResult Post([FromBody] ItemCreateBindingModel itemCreateModel)
        {
            ItemDTO requestData = new ItemDTO() { ItemId = itemCreateModel.ItemId, Text = itemCreateModel.Name };
            _service.Create(requestData);
            return Ok(requestData);
        }
        [HttpPut("{itemId}")]
        public IActionResult Put(int itemId, [FromBody] ItemUpdateBindingModel itemUpdateModel)
        {
            ItemDTO requestData = new ItemDTO() { ItemId = itemUpdateModel.ItemId, Text = itemUpdateModel.Name};
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
