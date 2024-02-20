using eshop.DataAccess.Repositories;
using eshop.Entities;
using eshop.Services.DataTransferObjects.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public IEnumerable<ProductCardResponse> GetProducts()
        {
            var products = productRepository.GetAll();

            var response = products.Select(p => new ProductCardResponse
            {
                Description = p.Description,
                Id = p.Id,
                DiscountRate = p.DiscountRate,
                ImageUrl = p.ImageUrl,
                Name = p.Name,
                Price = p.Price,
            });

            return response;


        }
    }
}
