using Ecommerce.Models.EntityModels;
using Ecommerce.Models.UtilityModels;
using Ecommerce.Repositories.Abstractions;
using Ecommerce.WebApp.Models;
using Ecommerce.WebApp.Models.CustomerList;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ecommerce.WebApp.Controllers
{
    public class CustomerController : Controller
    {
        ICustomerRepository _customerRepository;
        ICustomerCategoryRepository _customerCategoryRepository;

        public CustomerController(ICustomerRepository customerRepository, ICustomerCategoryRepository customerCategoryRepository)
        {
            _customerRepository = customerRepository;
            _customerCategoryRepository = customerCategoryRepository;
        }

        public IActionResult Index(CustomerSearchCriteria customerSearchCriteria)
        {
            var customers = _customerRepository.Search(customerSearchCriteria);

            ICollection<CustomerListItem> customerModels = customers.Select(c => new CustomerListItem()
            {
                Id = c.Id,
                Name =c.Name,
                Email = c.Email,
                Phone = c.Phone,

            }).ToList();

            var customerListModel = new CustomerListViewModel();
            customerListModel.CustomerList = customerModels;
            return View(customerListModel);
        }
        public IActionResult Create()
        {
            CustomerCreate model = GetCustomerModelWithCategory();
            return View(model);
        }

        private CustomerCreate GetCustomerModelWithCategory()
        {
            var categories = _customerCategoryRepository.GetAll();
            var categoryListItem = categories.Select(c => new SelectListItem()
            {
                Value = c.Id.ToString(),
                Text = c.Name,
            });
            var model = new CustomerCreate();
            model.Categories = categoryListItem;
            return model;
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
                    return RedirectToAction("Index");
                }
            }
            var createModel = GetCustomerModelWithCategory();
            model.Categories = createModel.Categories;
            return View(model);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null||id<=0)
            {
                ViewBag.Error = "Please Provide proper id.";
                return View();
            }
            var customer = _customerRepository.GetById((int)id);

            if (customer == null)
            {
                ViewBag.Error = "No customer found for this id.";
                return View();
            }
            var model = new CustomerEditVM()
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email,
                Phone = customer.Phone
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(CustomerEditVM model)
        {
            if(ModelState.IsValid)
            {
                var customer = _customerRepository.GetById(model.Id);
                if (customer == null)
                {
                    ViewBag.Error = "No customer found for update.";
                    return View(model);
                }

                customer.Name = model.Name;
                customer.Email = model.Email;
                customer.Phone = model.Phone;

                bool isSucces = _customerRepository.Update(customer);
                if (isSucces)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }
    }
}
