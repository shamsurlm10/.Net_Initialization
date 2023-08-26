using Ecommerce.Models.EntityModels;
using Ecommerce.Repositories;
using Ecommerce.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.WebApp.Controllers
{
    public class CustomerController : Controller
    {
        CustomerRepository _customerRepository;

        public CustomerController()
        {
            _customerRepository = new CustomerRepository();
        }

        public IActionResult Index()
        {
            var customers = _customerRepository.GetAll();

            ICollection<CustomerListViewModel> customerModels = customers.Select(c => new CustomerListViewModel()
            {
                Name =c.Name,
                Email = c.Email,
                Phone = c.Phone,

            }).ToList();
            return View(customerModels);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CustomerCreate model)
        {
            if (ModelState.IsValid)
            {
                var customer = new Customer()
                {
                    Name = model.Name,
                    Email = model.Email,
                    Phone = model.Phone,
                };
                var isSucces = _customerRepository.Add(customer);
                if (isSucces)
                {
                    return View();
                }
            }
            return View();
        }
        public IActionResult Edit(int? id) 
        {
            
        }

        [HttpPost]
        public IActionResult Edit(int? id)
        {

        }
    }
}
