using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace nkmlab7.Models
{
    public class ModelAccount
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Ho va ten")]
        [Required(ErrorMessage = "Vui long nhap ho va ten")]
        [MinLength(6, ErrorMessage = "Ho va ten phai co it nhat 6 ky tu")]
        [MaxLength(20, ErrorMessage = "Ho va ten khong duoc qua 20 ky tu")]
        public string? FullName { get; set; }

        [Display(Name = "Dia chi Email")]
        [Required(ErrorMessage = "Vui long nhap dia chi email")]
        [EmailAddress(ErrorMessage = "Dia chi email khong hop le")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Display(Name = "So dien thoai")]
        [DataType(DataType.PhoneNumber)]
        [Remote(action:"VerifyPhone",controller:"Account")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "So dien thoai khong hop le")]
        [Required(ErrorMessage = "Vui long nhap so dien thoai")]
        public string? Phone { get; set; }

        [Display(Name = "Dia chi")]
        [Required(ErrorMessage = "Vui long nhap dia chi")]
        [StringLength(100, ErrorMessage = "Dia chi khong duoc qua 100 ky tu")]
        public string? Address { get; set; }

        [Display(Name = "Avatar")]
        public string? Avatar { get; set; }

        [Display(Name = "Ngay sinh")]
        [Required(ErrorMessage = "Vui long nhap ngay sinh")]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        [Display(Name = "Gioi tinh")]
        public string? Gender { get; set; }

        [Display(Name = "Mat khau")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Display(Name = "Facebook")]
        [Required(ErrorMessage = "Vui long nhap link Facebook")]
        [Url(ErrorMessage = "Link Facebook khong hop le")]
        public string? Facebook { get; set; }
    }
}