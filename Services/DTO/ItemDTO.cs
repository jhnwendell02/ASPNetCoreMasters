using System;
using System.Collections.Generic;
using System.Text;

namespace Services.DTO
{
    public class ItemDTO 
    {
        public string Text { get; set; }
        public int ItemId { get; set; }

        public Guid CreatedBy { get; set; }
        public DateTime DateCreated { get; set; } 
    }
}
