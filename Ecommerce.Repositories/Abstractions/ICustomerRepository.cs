using Ecommerce.Models.EntityModels;
using Ecommerce.Models.UtilityModels;

namespace Ecommerce.Repositories.Abstractions
{
    public interface ICustomerRepository
    {
        bool Add(Customer customer);
        bool AddRange(ICollection<Customer> customer);
        bool Update(Customer customer);
        bool UpdateRange(ICollection<Customer> customer);
        bool Delete(Customer customer);
        Customer GetById(int id);
        ICollection<Customer> GetAll();
        ICollection<Customer> Search(CustomerSearchCriteria customerSearchCriteria);
    }
}
