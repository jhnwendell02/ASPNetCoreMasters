using DomainModels;
using Services.DTO;
using System;
using System.Collections.Generic;

namespace Services
{
    public class ItemService
    {
        public int GetAll(int userId)
        {
            return userId;
        }
        public void Save(ItemDTO request)
        {
            Item item = new Item();
            item.Text = request.Text;
        }
    }
}
