using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreMastersTodoList.Api.ApiModels
{
    public class ItemCreateApiModel
    {
        [Required]
        [StringLength(128, MinimumLength = 1)]
        public string Text { get; set; }
        public int ItemId { get; set; }
    }
}
