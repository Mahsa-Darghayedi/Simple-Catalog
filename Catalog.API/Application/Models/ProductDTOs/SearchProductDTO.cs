namespace Catalog.API.Application.Models.ProductDTOs
{
    public class SearchProductDTO
    {
        public string FilterStr { get; set; } 
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }

        public string SortBy { get; set; } 
        public bool IsAsc { get; set; }
    }
}
