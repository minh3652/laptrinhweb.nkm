
using System.ComponentModel.DataAnnotations;

namespace nkmlab7.Models
{
    public class Product : IValidatableObject
    {
        public int Id { get; set; }

        [Display(Name = "Tên sản phẩm")]
        [Required(ErrorMessage = "Vui lòng nhập tên sản phẩm")]
        [MinLength(6, ErrorMessage = "Tên phải có ít nhất 6 ký tự")]
        [MaxLength(150, ErrorMessage = "Tên không được quá 150 ký tự")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Ảnh sản phẩm")]
        public string? Image { get; set; }

        [Display(Name = "Giá")]
        [Range(10000.01, float.MaxValue,
            ErrorMessage = "Giá phải lớn hơn 10000")]
        public float Price { get; set; }

        [Display(Name = "Giá khuyến mãi")]
        [Range(0, float.MaxValue,
            ErrorMessage = "Giá khuyến mãi không được âm")]
        public float SalePrice { get; set; }

        [Display(Name = "Mô tả")]
        [MaxLength(1500,
            ErrorMessage = "Mô tả không được quá 1500 ký tự")]
        public string? Description { get; set; }

        [Display(Name = "Danh mục")]
        [Range(1, int.MaxValue,
            ErrorMessage = "Vui lòng chọn danh mục")]
        public int CategoryId { get; set; }

        public Category? Category { get; set; }

        // Kiểm tra giá khuyến mãi
        public IEnumerable<ValidationResult> Validate(
            ValidationContext validationContext)
        {
            if (Price > 0 && SalePrice > Price * 0.9f)
            {
                yield return new ValidationResult(
                    "Giá khuyến mãi phải thấp hơn giá gốc ít nhất 10%.",
                    new[] { nameof(SalePrice) });
            }
        }
    }
}