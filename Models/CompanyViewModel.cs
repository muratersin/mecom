using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mecom.Models
{   

    public class GeneralViewModel
    {
        public Payment payment { get; set; }
        public Asset asset { get; set; }
        public Customer customer { get; set; }
        public Supplier supplier { get; set; }
    }
    
    public class CustomerViewModel
    {
        [Required(ErrorMessage = "'Müşteri Adı' alanı boş bırakılamaz.")]
        [Display(Name = "Müşteri Adı")]
        [StringLength(50, ErrorMessage = "Müşteri Adı en fazla 50 en az 2 karakter olmalıdır.", MinimumLength = 2)]
        public string name { get; set; }

        [Required(ErrorMessage = "'Müşteri Soyadı' alanı boş bırakılamaz.")]
        [Display(Name = "Müşteri Soyadı")]
        [StringLength(50, ErrorMessage = "Müşteri Soyadı en fazla 50 en az 2 karakter olmalıdır.", MinimumLength = 2)]
        public string lastName { get; set; }

        [Required(ErrorMessage = "Açık Adress boş bırakılamaz")]
        [Display(Name = "Açık Adress")]
        [StringLength(200, ErrorMessage = "Şirket Adı en fazla 200 en az 10 karakter olmalıdır.", MinimumLength = 10)]
        public string adress { get; set; }

        [Required(ErrorMessage = "Telefon numarası boş bırakılamaz.")]
        [Display(Name = "Müşteri Telefon Numarası")]
        [StringLength(10, ErrorMessage = "Müşteri telefon numarası sadece 10 hane olabilir. Başına sıfır koymadan yazınız.", MinimumLength = 10)]
        public string phone { get; set; }

        [Required(ErrorMessage = "Email boş bırakılamaz")]
        [EmailAddress]
        [Display(Name = "Müşteri Email")]
        [StringLength(80, ErrorMessage = "Müşteri Email en fazla 80 en az 6 karakter olmalıdır.", MinimumLength = 6)]
        public string email { get; set; }

        [Display(Name = "Şirket Adı(Zorunlu değil)")]
        [StringLength(80, ErrorMessage = "Şirket Adı en fazla 80 en az 2 karakter olmalıdır.", MinimumLength = 2)]
        public string companyName { get; set; }

        public string userId { get; set; }
    }

}