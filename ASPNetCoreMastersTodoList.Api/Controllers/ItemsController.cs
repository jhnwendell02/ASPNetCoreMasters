using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreMastersTodoList.Api.Controllers
{

    [ApiController]
    public class ItemsController : Controller
    {
        [HttpGet]
        [Route("/getall")]
        public IEnumerable<string> GetAll(int userId)
        {
            ItemService service = new ItemService();
            return service.GetAll(userId);
        }
    }
}
