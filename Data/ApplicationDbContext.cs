using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using test3.Models;

namespace test3.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<test3.Models.Expozitie> Expozitie { get; set; } = default!;
        public DbSet<test3.Models.Artisti> Artisti { get; set; } = default!;
        public DbSet<test3.Models.Vizitatori> Vizitatori { get; set; } = default!;
        public DbSet<test3.Models.Expozitii> Expozitii { get; set; } = default!;
        public DbSet<test3.Models.Bilete> Bilete { get; set; } = default!;
        public DbSet<test3.Models.Exponate> Exponate { get; set; } = default!;
        public DbSet<test3.Models.Categorii_de_exponate> Categorii_de_exponate { get; set; } = default!;
        public DbSet<test3.Models.Categorii_de_bilete> Categorii_de_bilete { get; set; } = default!;

        public DbSet<test3.Models.DTO_Exponate> DTO_Exponate { get; set; } = default!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ArtistExpozitie>()
                .HasKey(ac => new { ac.ArtistID, ac.ExpozitieID });

            modelBuilder.Entity<DTO_Exponate>().HasNoKey();


        }
        public DbSet<test3.Models.ArtistExpozitie> ArtistExpozitie { get; set; } = default!;
    }
}
