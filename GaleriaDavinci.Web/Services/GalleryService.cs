using GaleriaDavinci.Domain;
using GaleriaDavinci.Domain.Models;
using GaleriaDavinci.Web.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GaleriaDavinci.Web.Services
{
    public class GalleryService : IGalleryService
    {
        private readonly ApplicationDbContext _dbContext;

        public GalleryService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddReview()
        {
            throw new NotImplementedException();
        }

        public async Task<ArtPiece> GetLastArtPiece()
        {
            return await _dbContext.ArtPieces.OrderByDescending(ap => ap.Created).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Review>> GetReviewsByArtPiece(int artPieceId)
        {
            return await _dbContext.Reviews.Where(r => r.ArtPieceId == artPieceId).ToListAsync();
        }
    }
}
