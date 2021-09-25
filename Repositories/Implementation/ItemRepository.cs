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
            //Code to Delete
            int i = _dataContext.Items.Where(x => x.ItemId == id ).Select(x => x.ItemId).First();
            var rec = _dataContext.Items.ToList();
            rec.RemoveAll(x => rec.Any(xx => xx.ItemId == i));
        }

        public void Save(Item item)
        {
            //Code to save
        }
    }
}
