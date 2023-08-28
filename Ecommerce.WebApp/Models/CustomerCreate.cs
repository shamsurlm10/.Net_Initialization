using Ecommerce.Models.EntityModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.WebApp.Models
{
    public class CustomerCreate
    {
        [Required(ErrorMessage = "Please Provide Name")]
        public String Name { get; set; }
        [Required]
        public String Email { get; set; }
        [Required]
        public String Phone { get; set; }

        public int? CustomerCategoryId { get; set; }

        public IEnumerable<SelectListItem>? Categories { get; set; }
    }
}
