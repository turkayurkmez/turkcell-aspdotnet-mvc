using eshop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.DataAccess.Repositories
{
    public class FakeCategoryRepository : ICategoryRepository
    {
        public Category Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetAll()
        {
            return new List<Category>()
            {
                new(){ Id=1, Name ="Falan"},
                new(){ Id=2, Name ="Filan"}

            };
        }
    }
}
