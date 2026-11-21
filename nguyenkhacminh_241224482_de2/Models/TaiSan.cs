using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace nguyenkhacminh_241224482_de2.Models;

public partial class TaiSan
{
    [Key]
    public int MaTs { get; set; }

    [Display(Name = "Loại tài sản")]
    [Required(ErrorMessage = "Vui lòng chọn loại tài sản")]
    public int MaLoai { get; set; }

    [Display(Name = "Tên tài sản")]
    [Required(ErrorMessage = "Tên tài sản không được để trống")]
    public string TenTs { get; set; } = null!;

    [Display(Name = "Nguyên giá (triệu)")]
    [Required(ErrorMessage = "Nguyên giá không được để trống")]
    [Range(1, 2000, ErrorMessage = "Nguyên giá phải là số từ 1 đến 2000")]
    public decimal? NguyenGia { get; set; }

    [Display(Name = "Tên file ảnh")]
    [Required(ErrorMessage = "Tên file ảnh không được để trống")]
    [RegularExpression(@"^.+\.(jpg|jpeg|png|webp|JPG|JPEG|PNG|WEBP)$", ErrorMessage = "Tên file ảnh phải có đuôi: .jpg, .jpeg, .png hoặc .webp")]
    public string? Anh { get; set; }

    [ValidateNever]
    public virtual LoaiTaiSan? MaLoaiNavigation { get; set; }
}
