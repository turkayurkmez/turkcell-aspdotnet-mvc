using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Entities
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(120)]
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal? DiscountRate { get; set; }
        public string? ImageUrl { get; set; } = "https://cdn.dsmcdn.com/ty1131/product/media/images/prod/SPM/PIM/20240112/10/51ae25d2-1655-3ca9-8b5a-3192ff71efac/1_org_zoom.jpg";

        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? Stock { get; set; }
        public int? CriticalLevel { get; set; }

        public bool? IsActive { get; set; }

        public int? CategoryId { get; set; }
        public Category? Category { get; set; }



    }
}
