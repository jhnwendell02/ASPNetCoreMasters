using ASPNetCoreMastersTodoList.Api.ApiModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreMastersTodoList.Api.CustomValidationAttribute
{
    public class DescriptionValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            ItemCreateBindingModel createModel = (ItemCreateBindingModel)validationContext.ObjectInstance;

            bool doContain = value.ToString().ToLower().Contains(createModel.Name.ToLower());
            if (doContain)
                return ValidationResult.Success;
            else
            {
                return new ValidationResult("Your Description must have the name of the item.");
            }
        }
    }
}
