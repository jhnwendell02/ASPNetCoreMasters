using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreMastersTodoList.Api.ApiModels
{
    public class ConfirmBindingModel
    {
        [Required]
        public string Code { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
