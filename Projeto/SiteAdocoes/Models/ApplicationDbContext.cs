using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace SiteAdocoes.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Adocao> Adocoes { get; set; }
        public DbSet<Adotante> Adotantes { get; set; }
        public DbSet<Especie> Especies { get; set; }
        public DbSet<Porte> Portes { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adocao>().HasRequired(a => a.Adotante).WithMany().WillCascadeOnDelete(false);
            base.OnModelCreating(modelBuilder);
        }
    }
}