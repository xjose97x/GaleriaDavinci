using GaleriaDavinci.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GaleriaDavinci.Domain
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public DbSet<ArtPiece> ArtPieces { get; set; }
        public DbSet<Review> Reviews { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }


        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    //builder.Entity<ArtPiece>().HasData(new ArtPiece());
        //}
    }
}
