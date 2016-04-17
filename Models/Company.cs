using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mecom.Models
{
    public enum paymentKind
    {
        GiderFaturası,
        MaaşÖdemesi,
        TedarikçiÖdemesi,
        VergiÖdemesi,
    }

    public class Staff
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Çalışan Adı bış bırakılamaz.")]
        [StringLength(50, ErrorMessage = "Çalışan Adı en fazla 50 en az 2 karakter olmalıdır.", MinimumLength = 2)]
        [Display(Name = "Ad")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Çalışan Soyadı boş bırakılamaz")]
        [StringLength(50, ErrorMessage = "Çalışan Soyadı en fazla 50 en az 2 karakter olmalıdır.", MinimumLength = 2)]
        [Display(Name = "Soyad")]
        public string lastName { get; set; }

        [Required(ErrorMessage = "Telefon numarası boş bırakılamaz.")]
        [Display(Name = "Çalışan Telefon Numarası")]
        [StringLength(10, ErrorMessage = "Çalışan telefon numarası sadece 10 hane olabilir. Başına sıfır koymadan yazınız.", MinimumLength = 10)]
        public string phone { get; set; }

        [Required(ErrorMessage = "Email boş bırakılamaz")]
        [EmailAddress]
        [Display(Name = "Email")]
        [StringLength(80, ErrorMessage = "Çalışan Email en fazla 80 en az 6 karakter olmalıdır.", MinimumLength = 6)]
        public string email { get; set; }

        [Required(ErrorMessage = "Ünvan alanı boş bırakılamaz")]
        [StringLength(50, ErrorMessage = "Ünvan adı en fazla 50 en az 2 karakter olmalıdır.", MinimumLength = 2)]
        [Display(Name = "Ünvan")]
        public string profession { get; set; }

        [Required(ErrorMessage = "Maaş alanı boş bırakılamaz")]
        [Display(Name = "Maaş")]
        public double salary { get; set; }

        public string userId { get; set; }
        [ForeignKey("userId")]
        public virtual ApplicationUser user { get; set; }
    }

    public class Customer
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "'Müşteri Adı' alanı boş bırakılamaz.")]
        [Display(Name = "Ad")]
        [StringLength(50, ErrorMessage = "Müşteri Adı en fazla 50 en az 2 karakter olmalıdır.", MinimumLength = 2)]
        public string name { get; set; }

        [Required(ErrorMessage = "'Müşteri Soyadı' alanı boş bırakılamaz.")]
        [Display(Name = "Soyad")]
        [StringLength(50, ErrorMessage = "Müşteri Soyadı en fazla 50 en az 2 karakter olmalıdır.", MinimumLength = 2)]
        public string lastName { get; set; }

        public string fullName
        {
            get { return name + " " + lastName; }
        }

        [Required(ErrorMessage = "Telefon numarası boş bırakılamaz.")]
        [Display(Name = "Telefon Numarası")]
        [StringLength(10, ErrorMessage = "Müşteri telefon numarası sadece 10 hane olabilir. Başına sıfır koymadan yazınız.", MinimumLength = 10)]
        public string phone { get; set; }

        [Required(ErrorMessage = "Email boş bırakılamaz")]
        [EmailAddress]
        [Display(Name = "Email")]
        [StringLength(80, ErrorMessage = "Müşteri Email en fazla 80 en az 6 karakter olmalıdır.", MinimumLength = 6)]
        public string email { get; set; }

        [Display(Name = "Şirket Adı(Zorunlu değil)")]
        [StringLength(80, ErrorMessage = "Şirket Adı en fazla 80 en az 2 karakter olmalıdır.", MinimumLength = 2)]
        public string companyName { get; set; }

        public string userId { get; set; }
        [ForeignKey("userId")]
        public virtual ApplicationUser user { get; set; }
    }

    public class Supplier
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Tedarikçi Şirket Adı boş bırakılamaz.")]
        [Display(Name = "Şirket Adı")]
        [StringLength(50, ErrorMessage = "Tedarikçi Şirket Adı en fazla 50 en az 2 karakter olmalıdır.", MinimumLength = 2)]
        public string companyName { get; set; }

        [Required(ErrorMessage = "Tedarikçi Telefon Numarası boş bırakılamaz")]
        [Display(Name = "Telefon Numarası")]
        public string phone { get; set; }

        [Required(ErrorMessage = "Açık Adress boş bırakılamaz")]
        [Display(Name = "Açık Adress")]
        [StringLength(200, ErrorMessage = "Şirket Adı en fazla 200 en az 10 karakter olmalıdır.", MinimumLength = 10)]
        public string adress { get; set; }

        [Required(ErrorMessage = "Tedarikçi Email boş bırakılamaz.")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string email { get; set; }

        public string userId { get; set; }
        [ForeignKey("userId")]
        public virtual ApplicationUser user { get; set; }
    }

    public class Payment
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Tutar boş bırakılamaz.")]
        [Display(Name = "Tutar")]
        public double amount { get; set; }

        [Required(ErrorMessage = "Ödeme Türü boş bırakılamaz")]
        [Display(Name = "Ödeme Türü")]
        public string pk { get; set; }

        public string userId { get; set; }
        [ForeignKey("userId")]
        public virtual ApplicationUser user { get; set; }

        public int? purchaseInvoiceId { get; set; }

        [ForeignKey("purchaseInvoiceId")]
        public virtual PurchaseInvoice purchaseInvoice { get; set; }

    }

    public class Asset
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "Müşteri")]
        public int customerId { get; set; }
        [ForeignKey("customerId")]
        [Display(Name = "Müşteri")]
        public virtual Customer customer { get; set; }

        [Display(Name = "Ürün-Hizmet")]
        public int servicesId { get; set; }
        public virtual Service services { get; set; }

        [Display(Name = "Ödendi mi?")]
        public bool isPaid { get; set; }

        public string userId { get; set; }
        [ForeignKey("userId")]
        public virtual ApplicationUser user { get; set; }

        
        public int billOfSaleId { get; set; }

        [ForeignKey("billOfSaleId")]
        public virtual BillOfSale billOfSale { get; set; }
    }

    public class Service
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Hizmet ya da Ürün adı boş bırakılamaz.")]
        [Display(Name = "Hizmet-Ürün Adı")]
        [StringLength(60, ErrorMessage = "Hizmet-Ürün adı en fazla 60 en az 2 karakter olabilir.", MinimumLength = 2)]
        public string name { get; set; }

        [Required(ErrorMessage = "Fiyat alanı boş bırakılamaz")]
        [Display(Name = "Fiyat")]
        public double price { get; set; }

        public string userId { get; set; }
        [ForeignKey("userId")]
        public virtual ApplicationUser user { get; set; }
    }

    public class PurchaseInvoice
    {

        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Tutar gereklidir.")]
        [Display(Name = "Tutar")]
        public double amount { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormatAttribute(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        [Display(Name = "Fatura Tarihi")]
        public DateTime creationDate { get; set; }

        [Required(ErrorMessage = "Açıklama gereklidir.")]
        [Display(Name = "Açıklama")]
        public string explanation { get; set; }

        [Display(Name = "Ödendi Mi?")]
        public bool isPaid { get; set; }


        public string userId { get; set; }
        [ForeignKey("userId")]
        public virtual ApplicationUser user { get; set; }

        [Display(Name = "Tedarikçi")]
        public int supplierId { get; set; }
        [ForeignKey("supplierId")]
        public virtual Supplier supplier { get; set; }

        [Display(Name = "Tür")]
        public string kind { get; set; }

        public virtual ICollection<Payment> payment { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormatAttribute(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        [Display(Name = "Fatura Tarihi")]
        public DateTime lastPaymentDate { get; set; }
    }

    public class BillOfSale
    {

        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Tutar gereklidir.")]
        [Display(Name = "Tutar")]
        public double amount { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fatura Tarihi")]
        public DateTime? creationDate { get; set; }

        [Required(ErrorMessage = "Açıklama gereklidir.")]
        [Display(Name = "Açıklama")]
        public string explanation { get; set; }

        [Display(Name = "Ödendi Mi?")]
        public bool isPaid { get; set; }

        public string userId { get; set; }
        [ForeignKey("userId")]
        public virtual ApplicationUser user { get; set; }

        public virtual ICollection<Asset> asset { get; set; }
    }
}