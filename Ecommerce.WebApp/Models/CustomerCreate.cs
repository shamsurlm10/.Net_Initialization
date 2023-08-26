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
    }
}
