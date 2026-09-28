
namespace nkmlab7.Models
{
    public static class StoreData
    {
        public static List<Category> Categories { get; } = new();
        public static List<Product> Products { get; } = new();

        public static int NextCategoryId = 1;
        public static int NextProductId = 1;
    }
}