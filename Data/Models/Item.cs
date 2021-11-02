using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }

        public Guid CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
