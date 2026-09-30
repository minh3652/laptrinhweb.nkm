using System;
using System.ComponentModel.DataAnnotations;

namespace nkmsession5.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage = "Tên đăng nhập không được để trống")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Độ dài tên từ 3-20 ký tự")]
        public string UserName { get; set; }

        [Display(Name = "Họ và tên")]
        [Required(ErrorMessage = "Họ và tên không được để trống")]
        public string FullName { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Hãy nhập Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Gõ lại mật khẩu")]
        [Required(ErrorMessage = "Hãy nhập không khớp")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Mật khẩu không khớp")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Hòm thư")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email không bỏ trống")]
        public string Email { get; set; }

        [Display(Name = "Điện thoại")]
        [RegularExpression(@"^0\d{9,12}$", ErrorMessage = "Phải bắt đầu bằng 0 và dài 10-13 số")]
        public string Phone { get; set; }

        [Display(Name = "Ngày sinh")]
        public DateTime Birthday { get; set; }
    }
}