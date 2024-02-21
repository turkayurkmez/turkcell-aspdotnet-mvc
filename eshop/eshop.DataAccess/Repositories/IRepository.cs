using eshop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.DataAccess.Repositories
{
    public interface IRepository<T> where T : class, IEntity, new()
    {
        IEnumerable<T> GetAll();
        T Get(int id);

        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(int id);

        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);


    }
}
