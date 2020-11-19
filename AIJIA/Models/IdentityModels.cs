using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIJIA.Models
{
    // Vous pouvez ajouter des données de profil pour l'utilisateur en ajoutant d'autres propriétés à votre classe ApplicationUser. Pour en savoir plus, consultez https://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {

        [Required(ErrorMessage = "Le Nom est Obligatoire !")]
        [Display(Name = "Nom")]
        public string Lastename { get; set; }

        [Required(ErrorMessage = "Le Prenom est Obligatoire !")]
        [Display(Name = "Prenom")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Le Numéro de Telephone est Obligatoire !")]
        [Display(Name = "Telephone")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Le Code Postal est Obligatoire !")]
        [Display(Name = "Code Posatl")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Indiquer votre Ville !")]
        [Display(Name = "Ville")]
        public string City { get; set; }

        [Required(ErrorMessage = "Indiquer votre Pays !")]
        [Display(Name = "Pays")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Indiquer Votre Genre !")]
        [Display(Name = "Genre")]
        public string Sex { get; set; }

        [Required(ErrorMessage = "Votre Date De Naissance est Obligatoire !")]
        [Display(Name = "Anniversaire")]
        public DateTime Birthday { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Notez qu'authenticationType doit correspondre à l'élément défini dans CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Ajouter les revendications personnalisées de l’utilisateur ici
            return userIdentity;
        }
    }

    // Definitions Des Rôles pour les Utilisateurs 
    public class UserRole : IdentityRole 
    {
        public UserRole() : base() { }
        public UserRole(string roleName) : base(roleName) { }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public virtual DbSet<Mark> Marks { get; set; }
        public virtual DbSet<TypeArticle> TypeArticles { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Delivery> Deliveries { get; set; }
        public virtual DbSet<ModelDelivery> ModelDeliveries { get; set; }
        public virtual DbSet<Provider> Providers { get; set; }
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<StatusOrder> StatusOrders { get; set; }
        //public virtual DbSet<User> Userss { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        
    }
}