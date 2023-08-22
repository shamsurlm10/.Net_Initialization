using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    public class CustomerController: Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public String List()
        {
            return "this is home";
        }

        public String Create(CustomerCreate customer)
        {
            return $"this is create  name: {customer.Name}, phone: {customer.Phone}";
        }

    }
}