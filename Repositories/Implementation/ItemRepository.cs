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
        public ItemRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IQueryable<Item> All()
        {
            return _dataContext.Items.AsQueryable();
        }

        public void Delete(int id)
        {
            _dataContext.Items.RemoveAll(x => x.ItemId == id);
        }

        public void Save(Item item)
        {
            Item data = _dataContext.Items.Where(x => x.ItemId == item.ItemId).FirstOrDefault();
            if (data == null)
            {
                _dataContext.Items.Add(item);
            }
            else
            {
                data.Text = data.Text;
            }
        }
    }
}
