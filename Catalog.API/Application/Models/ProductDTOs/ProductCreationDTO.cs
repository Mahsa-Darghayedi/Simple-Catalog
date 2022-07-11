using Catalog.API.Application.Models.Validations.ProductValidation;
using System.ComponentModel.DataAnnotations;

namespace Catalog.API.Application.Models.ProductDTOs
{
    public class ProductCreationDTO
    {
        [ProductNameValidation]
        [Required(AllowEmptyStrings =false)]
        public string Name { get; set; }
        [Required(AllowEmptyStrings = false)]
        public int Price { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Description { get; set; }
    }
}
