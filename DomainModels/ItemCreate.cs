using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModels
{
    public class ItemCreate
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
