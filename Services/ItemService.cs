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
        private readonly ILogger<ItemService> _logger;
        public ItemService(IItemRepository repos, ILogger<ItemService> logger)
        {
            _repos = repos;
            _logger = logger;
        }
        public IEnumerable<ItemDTO> GetAll()
        {
            _logger.LogInformation("Getting all Items - {RequestTime}", DateTime.Now);
            var items = _repos.All();
            IEnumerable<ItemDTO> response = items.Select(s => new ItemDTO() { ItemId = s.ItemId, Text = s.Text });
            return response;
        }
        public ItemDTO Get(int itemId)
        {
            _logger.LogInformation("Getting Items by Id. ItemId = {ItemId}. {RequestTime}", itemId.ToString(), DateTime.Now);
            var items = _repos.All();
            return items.Select(s => new ItemDTO() { ItemId = s.ItemId, Text = s.Text, CreatedBy = s.CreatedBy }).Where(x => x.ItemId == itemId).FirstOrDefault();
        }
        public IEnumerable<ItemDTO> GetAllByFilter(ItemByFilterDTO filters)
        {
            _logger.LogInformation("Getting Items with Filter - {RequestTime}", DateTime.Now);
            var items = _repos.All();
            IEnumerable<ItemDTO> response = items.Select(s => new ItemDTO() { ItemId = s.ItemId, Text = s.Text }).Where(x => x.Text == filters.text);
            return response;
        }
        public void Add(ItemDTO request)
        {
            _logger.LogInformation("Adding Item. {RequestTime}", DateTime.Now);
            Item item = new Item();
            item.Text = request.Text;
            item.ItemId = request.ItemId;
            _repos.Save(item);
        }
        public void Save(ItemDTO request)
        {
            _logger.LogInformation("Saving Item. {RequestTime}", DateTime.Now);
            Item item = new Item();
            item.Text = request.Text;
            item.ItemId = request.ItemId;
            _repos.Save(item);
        }
        public void Update(ItemDTO request)
        {
            _logger.LogInformation("Updating Item. {RequestTime}", DateTime.Now);
            Item item = new Item();
            item.Text = request.Text;
            item.ItemId = request.ItemId; 
            _repos.Save(item);
        }
        public void Create(ItemDTO request, string userId)
        {
            _logger.LogInformation("Creating Item. {RequestTime}", DateTime.Now);
            ItemDTO item = new ItemDTO() { Text = request.Text, ItemId = request.ItemId };
            _repos.Create(new Item() { Text = request.Text }, userId);
        }
        public string Delete(int itemId)
        {
            _logger.LogInformation("Deleting Item by Id. ItemId = {ItemId}. {RequestTime}", itemId.ToString(), DateTime.Now);
            _repos.Delete(itemId);
            return "Successfully deleted item number " + itemId.ToString();
        }
    }
}
