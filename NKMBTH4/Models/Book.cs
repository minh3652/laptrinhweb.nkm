using Microsoft.AspNetCore.Mvc.Rendering;

namespace NKMBTH4.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public int AuthorId { get; set; }

        public int GenreId { get; set; }

        public string Image { get; set; } = string.Empty;

        public float Price { get; set; }

        public int TotalPage { get; set; }

        public string Sumary { get; set; } = string.Empty;


        // =====================================
        // LẤY DANH SÁCH SÁCH
        // =====================================
        public List<Book> GetBookList()
        {
            List<Book> books = new List<Book>
            {
                new Book()
                {
                    Id = 1,
                    Title = "Chí phèo",
                    AuthorId = 1,
                    GenreId = 1,
                    Image = "/Images/Product/images1.png",
                    Price = 500000,
                    Sumary = "",
                    TotalPage = 100
                },

                new Book()
                {
                    Id = 2,
                    Title = "Lão Hạc",
                    AuthorId = 1,
                    GenreId = 1,
                    Image = "/Images/Product/images2.png",
                    Price = 700000,
                    Sumary = "",
                    TotalPage = 200
                },

                new Book()
                {
                    Id = 3,
                    Title = "Conan Phiêu lưu ký",
                    AuthorId = 1,
                    GenreId = 1,
                    Image = "/Images/Product/images3.png",
                    Price = 550000,
                    Sumary = "",
                    TotalPage = 300
                },

                new Book()
                {
                    Id = 4,
                    Title = "Chí phèo",
                    AuthorId = 1,
                    GenreId = 1,
                    Image = "/Images/Product/images4.png",
                    Price = 850000,
                    Sumary = "",
                    TotalPage = 400
                }
            };

            return books;
        }


        // =====================================
        // LẤY SÁCH THEO ID
        // =====================================
        public Book? GetBookById(int id)
        {
            Book? book = GetBookList()
                .FirstOrDefault(b => b.Id == id);

            return book;
        }


        // =====================================
        // DANH SÁCH TÁC GIẢ
        // =====================================
        public List<SelectListItem> Authors { get; } = new List<SelectListItem>
        {
            new SelectListItem
            {
                Value = "1",
                Text = "Nam Cao"
            },

            new SelectListItem
            {
                Value = "2",
                Text = "Ngô Tất Tố"
            },

            new SelectListItem
            {
                Value = "3",
                Text = "Adamkhoom"
            },

            new SelectListItem
            {
                Value = "4",
                Text = "Thiền sư Thích Nhất Hạnh"
            }
        };


        // =====================================
        // DANH SÁCH THỂ LOẠI
        // =====================================
        public List<SelectListItem> Genres { get; } = new List<SelectListItem>
        {
            new SelectListItem
            {
                Value = "1",
                Text = "Truyện tranh"
            },

            new SelectListItem
            {
                Value = "2",
                Text = "Văn học đương đại"
            },

            new SelectListItem
            {
                Value = "3",
                Text = "Phật học phổ thông"
            },

            new SelectListItem
            {
                Value = "4",
                Text = "Truyện cười"
            }
        };
    }
}