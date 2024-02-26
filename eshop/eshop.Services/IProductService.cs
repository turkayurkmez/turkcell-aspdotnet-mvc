using eshop.Entities;
using eshop.Services.DataTransferObjects.Request;
using eshop.Services.DataTransferObjects.Response;

namespace eshop.Services
{
    public interface IProductService
    {
        IEnumerable<ProductCardResponse> GetProducts();
        Task<IEnumerable<ProductCardResponse>> GetProductsAsync();

        IEnumerable<ProductCardResponse> GetProductCardsByCategory(int id);
        Task<IEnumerable<ProductCardResponse>> GetProductCardsByCategoryAsync(int id);
        Task<ProductCardResponse> GetProductForAddToCardAsync(int id);

        Task<UpdateProductRequest> GetUpdateProductRequest(int id);


        Task<int> CreateAsync(CreateNewProductRequest request);
        Task UpdateAsync(UpdateProductRequest request);

        Task DeleteAsync(int id);



    }
}