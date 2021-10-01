using DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories
{
    public class DataContext
    {
        public DataContext()
        {
            Items = new List<Item>()
            {
                new Item() {ItemId = 1, Text = "Item 1" },
                new Item() {ItemId = 2, Text = "Item 2" },
                new Item() {ItemId = 3, Text = "Item 3" },
                new Item() {ItemId = 4, Text = "Item 4" },
                new Item() {ItemId = 5, Text = "Item 5" }
            };
        }
        public List<Item> Items { get; set; }
    }
}
