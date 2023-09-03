using Ecommerce.Models.EntityModels;
using Ecommerce.Models.UtilityModels;
using Ecommerce.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repositories
{
    public class CustomerCloudRepository : ICustomerRepository
    {
        public bool Add(Customer customer)
        {
            throw new NotImplementedException();
        }

        public bool AddRange(ICollection<Customer> customer)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Customer customer)
        {
            throw new NotImplementedException();
        }

        public ICollection<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public Customer GetById(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Customer> Search(CustomerSearchCriteria customerSearchCriteria)
        {
            throw new NotImplementedException();
        }

        public bool Update(Customer customer)
        {
            throw new NotImplementedException();
        }

        public bool UpdateRange(ICollection<Customer> customer)
        {
            throw new NotImplementedException();
        }
    }
}
