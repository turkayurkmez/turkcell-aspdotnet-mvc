using eshop.DataAccess.Data;
using eshop.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.DataAccess.Repositories
{
    public class EFProductRepository : IProductRepository
    {
        private readonly TurkcellDbContext dbContext;

        public EFProductRepository(TurkcellDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateAsync(Product entity)
        {
            await dbContext.Products.AddAsync(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var product = await dbContext.Products.AsNoTracking().SingleOrDefaultAsync(p => p.Id == id);

            dbContext.Remove(product);
            await dbContext.SaveChangesAsync();
        }

        public Product Get(int id)
        {
            return dbContext.Products.SingleOrDefault(p => p.Id == id);
        }

        public IEnumerable<Product> GetAll()
        {
            return dbContext.Products.ToList();
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await dbContext.Products.ToListAsync();
        }

        public async Task<Product> GetAsync(int id)
        {
            return await dbContext.Products.SingleOrDefaultAsync(p => p.Id == id);

        }

        public IEnumerable<Product> GetProductsByCategory(int id)
        {
            return dbContext.Products.Where(p => p.CategoryId == id);
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(int id)
        {
            return await dbContext.Products.Where(p => p.CategoryId == id).ToListAsync();
        }

        public async Task<bool> IsExists(int id)
        {
            return await dbContext.Products.AnyAsync(p => p.Id == id);
        }

        public IEnumerable<Product> Search(string name)
        {
            return dbContext.Products.Where(p => p.Name.Contains(name));
        }

        public async Task<IEnumerable<Product>> SearchAsync(string name)
        {
            return await dbContext.Products.Where(p => p.Name.Contains(name)).ToListAsync();
        }

        public async Task UpdateAsync(Product entity)
        {
            dbContext.Products.Update(entity);
            await dbContext.SaveChangesAsync();
        }
    }
}
