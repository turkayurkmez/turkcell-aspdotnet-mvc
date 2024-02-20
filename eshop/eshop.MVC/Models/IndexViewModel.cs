using eshop.Services.DataTransferObjects.Response;

namespace eshop.MVC.Models
{
    public class IndexViewModel
    {
        public IEnumerable<ProductCardResponse> ProductCardResponses { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
