namespace eshop.MVC.Models
{
    public class PagingInfo
    {
        public int TotalCount { get; set; }
        public int PageSize { get; set; }

        public int TotalPages { get => (int)Math.Ceiling((decimal)TotalCount / PageSize); }

        public int ActivePage { get; set; }


    }
}
