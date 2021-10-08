using GaleriaDavinci.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GaleriaDavinci.Domain
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<ArtPiece> ArtPieces { get; set; }
        public DbSet<Review> Reviews { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
