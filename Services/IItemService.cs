using Services.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IItemService
    {
        IEnumerable<ItemDTO> GetAll();
        ItemDTO Get(int itemId);
        IEnumerable<ItemDTO> GetAllByFilter(ItemByFilterDTO filters);
        void Add(ItemDTO itemDto);
        void Save(ItemDTO itemDto);
        void Update(ItemDTO itemDto);
        void Create(ItemDTO itemDto, string userId);
        string Delete(int itemId);
    }
}
