using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mecom.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        [Display(Name = "İsim")]
        [Required(ErrorMessage = "'İsim' alanı boş bırakılamaz.")]
        [StringLength(50,ErrorMessage = "'İsim' en fazla 50 en az 2 karakter olabilir",MinimumLength = 2)]
        public string name { get; set; }

        [Display(Name = "Soy İsim")]
        [Required(ErrorMessage = "'Soy İsim' alanı boş bırakılamaz.")]
        [StringLength(50, ErrorMessage = "'Soy İsim' en fazla 50 en az 2 karakter olabilir", MinimumLength = 2)]
        public string lastName { get; set; }

        [Display(Name = "İşletme Adı")]
        [Required(ErrorMessage = "'İşletme Adı' alanı boş bırakılamaz.")]
        [StringLength(50, ErrorMessage = "'İşletme Adı' en fazla 80 en az 5 karakter olabilir", MinimumLength = 5)]
        public string companyName { get; set; }

        [Display(Name = "Vergi Dairesi Numarası")]
        [StringLength(100, ErrorMessage = "VD en fazla 50 en az 5 karakter olmalıdır.", MinimumLength = 5)]
        public string vdNo { get; set; }

        [Display(Name = "Açık Adress")]
        [StringLength(200, ErrorMessage = "Şirket Adı en fazla 200 en az 10 karakter olmalıdır.", MinimumLength = 10)]
        public string adress { get; set; }

        public ICollection<Staff> staffs { get; set; } // Çalışanlar
        public ICollection<Customer> customers { get; set; } // Müşteriler
        public ICollection<Supplier> suppliers { get; set; } // Tedarikçiler
        public ICollection<Payment> payments { get; set; } // Ödemeler
        public ICollection<Asset> assets { get; set; } // Alacaklar
        public ICollection<Service> services { get; set; } // Hizmetler-Ürünler
        public ICollection<PurchaseInvoice> purschaseInovice { get; set; }
        public ICollection<BillOfSale> billOfSales { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<Service> Servicies { get; set; }
        public DbSet<PurchaseInvoice> PurchaseInvoices { get; set; }
        public DbSet<BillOfSale> BillOfSales { get; set; }
    }
}