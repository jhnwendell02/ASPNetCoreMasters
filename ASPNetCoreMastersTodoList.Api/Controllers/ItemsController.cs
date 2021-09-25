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
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(new ItemService().GetAll());
        }
        [HttpGet("{itemId}")]
        public IActionResult Get(int itemId)
        {
            return Ok(new ItemService().Get(itemId));
        }
        [HttpGet("filterBy")]
        public IActionResult GetByFilters([FromQuery] Dictionary<string, string> filters)
        {
            return Ok($"GetByFilters");
        }
        [HttpPost]
        public IActionResult Post([FromBody] ItemCreateBindingModel itemCreateModel)
        {
            ItemService service = new ItemService();
            ItemCreateDTO requestData = new ItemCreateDTO() { ItemId = itemCreateModel.ItemId, Description = itemCreateModel.Description, Name = itemCreateModel.Name };
            service.Create(requestData);
            return Ok(requestData);
        }
        [HttpPut("{itemId}")]
        public IActionResult Put(int itemId, [FromBody] ItemUpdateBindingModel itemUpdateModel)
        {
            ItemService service = new ItemService();
            ItemUpdateDTO requestData = new ItemUpdateDTO() { ItemId = itemUpdateModel.ItemId, Description = itemUpdateModel.Description, Name = itemUpdateModel.Name };
            service.Update(requestData);
            return Ok(requestData);
        }
        [HttpDelete("{itemId}")]
        public IActionResult Delete(int itemId)
        {
            return Ok(new ItemService().Delete(itemId));
        }
    }
}
