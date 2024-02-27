using AutoMapper;
using eshop.DataAccess.Repositories;
using eshop.Entities;
using eshop.Services.DataTransferObjects.Request;
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
        private readonly IMapper mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        public async Task<int> CreateAsync(CreateNewProductRequest request)
        {
            var product = mapper.Map<Product>(request);
            await productRepository.CreateAsync(product);
            return product.Id;
        }

        public async Task DeleteAsync(int id)
        {
            await productRepository.DeleteAsync(id);
        }

        public IEnumerable<ProductCardResponse> GetProductCardsByCategory(int id)
        {
            var products = productRepository.GetProductsByCategory(id);

            // TODO 1: Automapper eklemeyi unutma!

            //var response = products.Select(p => new ProductCardResponse
            //{
            //    Description = p.Description,
            //    Id = p.Id,
            //    DiscountRate = p.DiscountRate,
            //    ImageUrl = p.ImageUrl,
            //    Name = p.Name,
            //    Price = p.Price,
            //});

            var response = mapper.Map<IEnumerable<ProductCardResponse>>(products);
            return response;

        }

        public async Task<IEnumerable<ProductCardResponse>> GetProductCardsByCategoryAsync(int id)
        {
            var products = await productRepository.GetProductsByCategoryAsync(id);
            return mapper.Map<IEnumerable<ProductCardResponse>>(products);
        }

        public ProductCardResponse GetProductForAddToCard(int id)
        {
            var product = productRepository.Get(id);
            return mapper.Map<ProductCardResponse>(product);
        }

        public async Task<ProductCardResponse> GetProductForAddToCardAsync(int id)
        {
            var product = await productRepository.GetAsync(id);
            return mapper.Map<ProductCardResponse>(product);
        }

        public IEnumerable<ProductCardResponse> GetProducts()
        {
            var products = productRepository.GetAll();
            var response = mapper.Map<IEnumerable<ProductCardResponse>>(products);
            return response;


        }

        public async Task<IEnumerable<ProductCardResponse>> GetProductsAsync()
        {
            var products = await productRepository.GetAllAsync();
            var response = mapper.Map<IEnumerable<ProductCardResponse>>(products);
            return response;
        }

        public async Task<UpdateProductRequest> GetUpdateProductRequest(int id)
        {
            var product = await productRepository.GetAsync(id);
            return mapper.Map<UpdateProductRequest>(product);
        }

        public async Task<bool> ProductIsExists(int id)
        {
            return await productRepository.IsExists(id);
        }

        public async Task<IEnumerable<ProductCardResponse>> Search(string name)
        {
            var products = await productRepository.SearchAsync(name);
            return mapper.Map<IEnumerable<ProductCardResponse>>(products);
        }

        public async Task UpdateAsync(UpdateProductRequest request)
        {
            var product = mapper.Map<Product>(request);
            await productRepository.UpdateAsync(product);

        }
    }
}
