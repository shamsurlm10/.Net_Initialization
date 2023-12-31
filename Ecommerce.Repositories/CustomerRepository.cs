﻿using Ecommerce.Database;
using Ecommerce.Models.EntityModels;
using Ecommerce.Models.UtilityModels;
using Ecommerce.Repositories.Abstractions;

namespace Ecommerce.Repositories
{
    public class CustomerRepository: ICustomerRepository
    {
        ApplicationDbContext _db;

        public CustomerRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool Add(Customer customer)
        {
            _db.Customers.Add(customer);
            return _db.SaveChanges()>0;
        }
        public bool AddRange(ICollection<Customer> customer) 
        {
            _db.Customers.AddRange(customer);
            return _db.SaveChanges() > 0;
        }
        public bool Update(Customer customer)
        {
            _db.Customers.Update(customer);
            return _db.SaveChanges()>0;
        }
        public bool UpdateRange(ICollection<Customer> customer)
        {
            _db.Customers.UpdateRange(customer);
            return _db.SaveChanges() > 0;
        }
        public bool Delete(Customer customer)
        {
            _db.Customers.Remove(customer);
            return _db.SaveChanges() > 0;
        }
        public Customer GetById(int id)
        {
            return _db.Customers.FirstOrDefault(c => c.Id == id);
        }
        public ICollection<Customer> GetAll()
        {
            return _db.Customers.ToList();
        }
        public ICollection<Customer> Search(CustomerSearchCriteria customerSearchCriteria)
        {
            //imediate execution
            var customers = _db.Customers.AsQueryable();

            if(customerSearchCriteria != null && !string.IsNullOrEmpty(customerSearchCriteria.Name))
            {
                customers = customers.Where(c=>c.Name.ToLower().Contains(customerSearchCriteria.Name.ToLower()));
            }
            if (customerSearchCriteria != null && !string.IsNullOrEmpty(customerSearchCriteria.Phone))
            {
                customers = customers.Where(c => c.Phone.ToLower().Contains(customerSearchCriteria.Phone.ToLower()));
            }
            if (customerSearchCriteria != null && !string.IsNullOrEmpty(customerSearchCriteria.Email))
            {
                customers = customers.Where(c => c.Email.ToLower().Contains(customerSearchCriteria.Email.ToLower()));
            }

            int skipSize = (customerSearchCriteria.CurrentPage-1)*customerSearchCriteria.PageSize;
            return customers.Skip(skipSize).Take(customerSearchCriteria.PageSize).ToList();
        }
    }
}
