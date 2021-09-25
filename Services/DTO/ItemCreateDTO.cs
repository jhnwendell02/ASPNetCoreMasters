using System;
using System.Collections.Generic;
using System.Text;

namespace Services.DTO
{
    public class ItemCreateDTO
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
