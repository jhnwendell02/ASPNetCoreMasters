using DomainModels;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class ItemService
    {
        private readonly List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        public List<int> GetAll()
        {
            return numbers;

        }
        public int Get(int userId)
        {
            return numbers.Where(x => x == userId).FirstOrDefault();
        }
        public void Save(ItemDTO request)
        {
            Item item = new Item();
            item.Text = request.Text;
        }
        public void Update(ItemUpdateDTO request)
        {
            ItemUpdate item = new ItemUpdate() { Name = request.Name, Description = request.Description, ItemId = request.ItemId };
        }
        public void Create(ItemCreateDTO request)
        {
            ItemCreate item = new ItemCreate() { Name = request.Name, Description = request.Description, ItemId = request.ItemId };
        }
        public string Delete(int itemId)
        {
            return "Successfully deleted item number " + itemId.ToString();
        }
    }
}
