using NKMBTTL4.Models;

namespace NKMBTTL4.Data
{
    public static class ProductData
    {
        // ==================================================
        // DANH MỤC
        // ==================================================

        public static List<Category> Categories { get; } = new List<Category>
        {
            new Category
            {
                Id = 1,
                Name = "Áo dài"
            },

            new Category
            {
                Id = 2,
                Name = "Áo đóng"
            },

            new Category
            {
                Id = 3,
                Name = "Túi xách"
            },

            new Category
            {
                Id = 4,
                Name = "Đồng hồ"
            },

            new Category
            {
                Id = 5,
                Name = "Ví da"
            },

            new Category
            {
                Id = 6,
                Name = "Thắt lưng da"
            },

            new Category
            {
                Id = 7,
                Name = "Tủ lạnh"
            },

            new Category
            {
                Id = 8,
                Name = "Tivi"
            },

            new Category
            {
                Id = 9,
                Name = "Quạt điện"
            },

            new Category
            {
                Id = 10,
                Name = "Lò sưởi"
            }
        };


        // ==================================================
        // SẢN PHẨM
        // ==================================================

        public static List<Product> Products { get; } = new List<Product>
        {
            new Product
            {
                Id = 1,

                Name = "Nồi cơm điện cao tần Nagakawa NAG0102",

                Price = 1290000,

                ImageUrl = "/images/products/product1.jpg",

                CategoryId = 1,

                CreatedAt = new DateTime(2026, 9, 11)
            },

            new Product
            {
                Id = 2,

                Name = "Nồi cơm điện cao tần Nagakawa NAG0102",

                Price = 1290000,

                ImageUrl = "/images/products/product2.jpg",

                CategoryId = 2,

                CreatedAt = new DateTime(2026, 9, 10)
            },

            new Product
            {
                Id = 3,

                Name = "Nồi cơm điện cao tần Nagakawa NAG0102",

                Price = 1290000,

                ImageUrl = "/images/products/product3.jpg",

                CategoryId = 3,

                CreatedAt = new DateTime(2026, 9, 9)
            },

            new Product
            {
                Id = 4,

                Name = "Nồi cơm điện cao tần Nagakawa NAG0102",

                Price = 1290000,

                ImageUrl = "/images/products/product1.jpg",

                CategoryId = 4,

                CreatedAt = new DateTime(2026, 9, 8)
            },

            new Product
            {
                Id = 5,

                Name = "Nồi cơm điện cao tần Nagakawa NAG0102",

                Price = 1290000,

                ImageUrl = "/images/products/product2.jpg",

                CategoryId = 5,

                CreatedAt = new DateTime(2026, 9, 7)
            },

            new Product
            {
                Id = 6,

                Name = "Nồi cơm điện cao tần Nagakawa NAG0102",

                Price = 1290000,

                ImageUrl = "/images/products/product3.jpg",

                CategoryId = 6,

                CreatedAt = new DateTime(2026, 9, 6)
            }
        };
    }
}