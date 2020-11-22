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

        [Display(Name = "Nom")]
        public string Lastename { get; set; }

        [Display(Name = "Prénom")]
        public string Firstname { get; set; }


        [Display(Name = "Code Postal")]
        public string PostalCode { get; set; }

        [Display(Name = "Adresse")]
        public string Address { get; set; }

        [Display(Name = "Tel")]
        public string Phone { get; set; }

        [Display(Name = "Ville")]
        public string City { get; set; }

        [Display(Name = "Pays")]
        public string Country { get; set; }


        [Display(Name = "Civilité")]
        public string Sex { get; set; }


        [Display(Name = "Date de Naissance")]
        public string Birthday { get; set; }


        [Display(Name = "Admin")]
        public string IsAdmin { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Notez qu'authenticationType doit correspondre à l'élément défini dans CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Ajouter les revendications personnalisées de l’utilisateur ici
            userIdentity.AddClaim(new Claim("Firstname", this.Firstname));
            userIdentity.AddClaim(new Claim("Lastname", this.Lastename));
            userIdentity.AddClaim(new Claim("PostalCode", this.PostalCode));
            userIdentity.AddClaim(new Claim("City", this.City));
            userIdentity.AddClaim(new Claim("Country", this.Country));
            userIdentity.AddClaim(new Claim("Sex", this.Sex));
            userIdentity.AddClaim(new Claim("Birthday", this.Birthday));
            userIdentity.AddClaim(new Claim("Phone", this.Phone));
            userIdentity.AddClaim(new Claim("Address", this.Address));
            userIdentity.AddClaim(new Claim("IsAdmin", this.IsAdmin));
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