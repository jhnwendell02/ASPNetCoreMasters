using ASPNetCoreMastersTodoList.Api.ApiModels;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreMastersTodoList.Api.Controllers
{
    public class ItemsController : Controller
    {
        public int Get(int userId)
        {
            return userId;
        }
        public void Post(ItemCreateApiModel request)
        {
            if (ModelState.IsValid)
            {
                ItemService service = new ItemService();
                ItemDTO serviceItem = new ItemDTO();
                serviceItem.Text = request.Text;
                service.Save(serviceItem);
            }
        }
    }
}
