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

        public async Task<IEnumerable<ArtPiece>> GetPaginatedArtPieces(int size, int page)
        {
            return await _dbContext.ArtPieces.OrderByDescending(ap => ap.Created).Skip(size * (page - 1)).Take(size).ToListAsync();
        }
     }
}
