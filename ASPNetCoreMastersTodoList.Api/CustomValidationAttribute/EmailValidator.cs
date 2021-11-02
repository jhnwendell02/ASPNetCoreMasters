using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreMastersTodoList.Api.CustomValidationAttribute
{
    public class EmailValidator : ValidationAttribute
    {
        private string allowedDomain { get; set; }
        public EmailValidator(string allowedDomain)
        {
            this.allowedDomain = allowedDomain;
        }
        public override bool IsValid(object value)
        {
            string[] array = value.ToString().Split("@");
            if (array.Length > 1)
                return array[1].ToLower() == allowedDomain.ToLower();
            else
            {
                return false;
            }
        }
    }
}
