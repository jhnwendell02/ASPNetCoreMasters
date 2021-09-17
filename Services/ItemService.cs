using DomainModels;
using Services.DTO;
using System;
using System.Collections.Generic;

namespace Services
{
    public class ItemService
    {
        public IEnumerable<string> GetAll(int userId)
        {
            return  new List<string>() { "jcustodio", "wcustodio", "jwcustodio" };
        }
        public void Save(ItemDTO request)
        {
            Item item = new Item();
            item.Text = request.Text;
        }
    }
}
