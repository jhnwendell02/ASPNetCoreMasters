using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Datas.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
    }
}
