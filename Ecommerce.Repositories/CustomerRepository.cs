﻿using Ecommerce.Database;
using Ecommerce.Models.EntityModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repositories
{
    public class CustomerRepository
    {
        ApplicationDbContext _db;

        public CustomerRepository()
        {
            _db = new ApplicationDbContext();
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
    }
}