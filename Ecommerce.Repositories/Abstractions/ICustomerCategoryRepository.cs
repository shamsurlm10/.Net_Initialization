using Ecommerce.Models.EntityModels;


namespace Ecommerce.Repositories.Abstractions
{
    public interface ICustomerCategoryRepository
    {
        ICollection<CustomerCategory> GetAll();
    }
}
