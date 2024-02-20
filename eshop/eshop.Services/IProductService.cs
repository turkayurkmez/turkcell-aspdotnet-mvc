using eshop.Entities;
using eshop.Services.DataTransferObjects.Response;

namespace eshop.Services
{
    public interface IProductService
    {
        IEnumerable<ProductCardResponse> GetProducts();
    }
}