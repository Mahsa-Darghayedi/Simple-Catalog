using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Catalog.API.Application.Models.Validations.ProductValidation
{
    public class ProductNameValidation : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
                return false;
            else
                return !(value.ToString()?.ToArray().Any(c=> !char.IsLetterOrDigit(c))) ?? false; 
        }
    }
}
