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

        public async Task<ArtPiece> GetArtPieceById(int id)
        {
            return await _dbContext.ArtPieces.FirstOrDefaultAsync(ap => ap.ID == id);
        }


        public async Task AddReview(int artPieceId, string authorName, int value, string comment)
        {
                await _dbContext.AddAsync(new Review(artPieceId, authorName, value, comment));
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ArtPiece>> GetPaginatedArtPieces(int size, int page)
        {
            return await _dbContext.ArtPieces.OrderByDescending(ap => ap.Created).Skip(size * (page - 1)).Take(size).ToListAsync();
        }
     }
}
