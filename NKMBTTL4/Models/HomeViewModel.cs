namespace NKMBTTL4.Models
{
    public class HomeViewModel
    {
        public List<Category> Categories { get; set; } = new();

        public List<Product> LatestProducts { get; set; } = new();
    }
}