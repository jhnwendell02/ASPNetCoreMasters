using Data;
using DomainModels;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositories.Implementation
{
    public class ItemRepository : IItemRepository
    {
        public readonly DataContext _dataContext;
        public readonly ItemDBContext _itemContext;
        public ItemRepository(DataContext dataContext, ItemDBContext itemContext)
        {
            _dataContext = dataContext;
            _itemContext = itemContext;
        }
        public IQueryable<Item> All()
        {
            return _itemContext.Item.Select(x => new Item { 
                ItemId = x.Id,
                Text = x.Text,
                CreatedBy = x.CreatedBy,
                DateCreated = x.DateCreated
            }).AsQueryable();
            //return _dataContext.Items.AsQueryable();
        }

        public void Delete(int id)
        {
            Data.Models.Item itemData = _itemContext.Item.Find(id);
            if (itemData == null) { throw new Exception("Unable to find the Item"); }
            _itemContext.Item.Remove(itemData);
            _itemContext.SaveChanges();
        }

        public void Save(Item item)
        {
            Data.Models.Item itemData = _itemContext.Item.Find(item.ItemId);
            if (itemData == null)
            {
                _itemContext.Item.Add(new Data.Models.Item() { Text = item.Text, CreatedBy = item.CreatedBy, DateCreated = DateTime.Now});
                _itemContext.SaveChanges();
            }
            else
            {
                itemData.Text = item.Text;
                _itemContext.SaveChanges();
            }
        }
        public void Create(Item item, string userId)
        {
            var aaa = Guid.Parse(userId);
            _itemContext.Item.Add(new Data.Models.Item() { Text = item.Text, CreatedBy = Guid.Parse(userId), DateCreated = DateTime.Now });
            _itemContext.SaveChanges();
        }
    }
}
