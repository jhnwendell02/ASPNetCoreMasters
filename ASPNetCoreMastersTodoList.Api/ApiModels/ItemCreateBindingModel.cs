using ASPNetCoreMastersTodoList.Api.CustomValidationAttribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreMastersTodoList.Api.ApiModels
{
    public class ItemCreateBindingModel
    {

        public int ItemId { get; set; }
        [Required]
        public string Name { get; set; }
        [DescriptionValidator]
        public string Description { get; set; }
    }
}
