using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mecom.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Kod")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Bu Tarayıcı Hatırlansın Mı?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email boş bırakılamaz")]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        public string Password { get; set; }

        [Display(Name = "Beni Hatırla")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "İsim")]
        [Required(ErrorMessage = "'İsim' alanı boş bırakılamaz.")]
        [StringLength(50, ErrorMessage = "'İsim' en fazla 50 en az 2 karakter olabilir", MinimumLength = 2)]
        public string name { get; set; }

        [Display(Name = "Soy İsim")]
        [Required(ErrorMessage = "'Soy İsim' alanı boş bırakılamaz.")]
        [StringLength(50, ErrorMessage = "'Soy İsim' en fazla 50 en az 2 karakter olabilir", MinimumLength = 2)]
        public string lastName { get; set; }

        [Display(Name = "İşletme Adı")]
        [Required(ErrorMessage = "'İşletme Adı' alanı boş bırakılamaz.")]
        [StringLength(50, ErrorMessage = "'İşletme Adı' en fazla 80 en az 5 karakter olabilir", MinimumLength = 5)]
        public string companyName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "'Şifre' en fazla 100 en az 6 karakter olmalıdır.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Şifre Doğrulama")]
        [Compare("Password", ErrorMessage = "Şifre ve Şifre Doğrulama uyuşmuyor.")]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "'Şifre' en fazla 100 en az 6 karakter olmalıdır.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Şifre Doğrulama")]
        [Compare("Şifre", ErrorMessage = "Şifre ve Şifre Doğrulama uyuşmuyor.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
