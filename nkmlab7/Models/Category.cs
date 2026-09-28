
using System.ComponentModel.DataAnnotations;

namespace nkmlab7.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Display(Name = "Tên danh mục")]
        [Required(ErrorMessage = "Vui lòng nhập tên danh mục")]
        [MinLength(6, ErrorMessage = "Tên phải có ít nhất 6 ký tự")]
        [MaxLength(150, ErrorMessage = "Tên không được quá 150 ký tự")]
        public string Name { get; set; } = string.Empty;
    }
}