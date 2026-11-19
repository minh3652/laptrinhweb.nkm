using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace nguyenkhacminh__241224482_de2026.Models;

public partial class Sach
{
    public int MaSach { get; set; }

    public int MaTl { get; set; }
    [Required(ErrorMessage = "Tên sách không được để trống")]
    public string TenSach { get; set; } = null!;
    [Required(ErrorMessage = "Giá sách không được để trống")]
    [Range(50,1000,ErrorMessage ="Gia tu 50 -10000")]
    public decimal? Gia { get; set; }
    [RegularExpression(@".+\.(jpg|jpeg|png|gif)$", ErrorMessage = "Chỉ chấp nhận các định dạng ảnh: .jpg, .jpeg, .png, .gif")]
    public string? Anh { get; set; }

    public virtual TheLoai MaTlNavigation { get; set; } = null!;
}
