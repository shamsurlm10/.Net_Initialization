using Ecommerce.Database;
using Ecommerce.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repositories.Abstractions
{
    public interface ICustomerCategoryRepository
    {
        ICollection<CustomerCategory> GetAll();
    }
}
