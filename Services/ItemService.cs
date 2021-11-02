using DomainModels;
using Microsoft.Extensions.Logging;
using Repositories;
using Repositories.Interfaces;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class ItemService : IItemService
    {
        private readonly List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        public readonly IItemRepository _repos;
        public ItemService(IItemRepository repos)
        {
            _repos = repos;
        }
        public IEnumerable<ItemDTO> GetAll()
        {
            var items = _repos.All();
            IEnumerable<ItemDTO> response = items.Select(s => new ItemDTO() { ItemId = s.ItemId, Text = s.Text, CreatedBy = s.CreatedBy, DateCreated = s.DateCreated });
            return response;
        }
        public ItemDTO Get(int itemId)
        {
            var items = _repos.All();
            return items.Select(s => new ItemDTO() { ItemId = s.ItemId, Text = s.Text, CreatedBy = s.CreatedBy, DateCreated = s.DateCreated }).Where(x => x.ItemId == itemId).FirstOrDefault();
        }
        public IEnumerable<ItemDTO> GetAllByFilter(ItemByFilterDTO filters)
        {
            var items = _repos.All();
            IEnumerable<ItemDTO> response = items.Select(s => new ItemDTO() { ItemId = s.ItemId, Text = s.Text }).Where(x => x.Text == filters.text);
            return response;
        }
        public void Add(ItemDTO request)
        {
            Item item = new Item();
            item.Text = request.Text;
            item.ItemId = request.ItemId;
            _repos.Save(item);
        }
        public void Save(ItemDTO request)
        {
            Item item = new Item();
            item.Text = request.Text;
            item.ItemId = request.ItemId;
            _repos.Save(item);
        }
        public void Update(ItemDTO request)
        {
            Item item = new Item();
            item.Text = request.Text;
            item.ItemId = request.ItemId; 
            _repos.Save(item);
        }
        public void Create(ItemDTO request, string userId)
        {
            ItemDTO item = new ItemDTO() { Text = request.Text, ItemId = request.ItemId };
            _repos.Create(new Item() { Text = request.Text }, userId);
        }
        public string Delete(int itemId)
        {
            _repos.Delete(itemId);
            return "Successfully deleted item number " + itemId.ToString();
        }
    }
}
