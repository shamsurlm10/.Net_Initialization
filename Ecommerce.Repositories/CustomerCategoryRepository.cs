using Ecommerce.Database;
using Ecommerce.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repositories
{
    public class CustomerCategoryRepository
    {
        ApplicationDbContext _db;
        public CustomerCategoryRepository() {
            _db = new ApplicationDbContext();
        }
        public ICollection<CustomerCategory> GetAll()
        {
            return _db.CustomerCategories.ToList();
        }

    }
}
