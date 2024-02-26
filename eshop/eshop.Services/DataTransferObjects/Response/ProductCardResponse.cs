using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Services.DataTransferObjects.Response
{
    public class ProductCardResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountRate { get; set; }
        public string ImageUrl { get; set; } = "https://cdn.dsmcdn.com/ty1131/product/media/images/prod/SPM/PIM/20240112/10/51ae25d2-1655-3ca9-8b5a-3192ff71efac/1_org_zoom.jpg";

        public int CategoryId { get; set; }
    }
}
