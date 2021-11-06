using GaleriaDavinci.Domain;
using GaleriaDavinci.Domain.Models;
using GaleriaDavinci.Web.Interfaces;
using GaleriaDavinci.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
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

        public async Task<IEnumerable<ArtPiece>> GetArtPieceByAuthor(string authorId)
        {
            return await _dbContext.ArtPieces.Where(ap => ap.AuthorId == authorId).ToListAsync();
        }

        public async Task AddReview(int artPieceId, string authorName, int value, string comment)
        {
                await _dbContext.AddAsync(new Review(artPieceId, authorName, value, comment));
            await _dbContext.SaveChangesAsync();
        }

        public async Task<PaginatedResult<ArtPiece>> GetPaginatedArtPieces(int size, int page)
        {
            var content =  await _dbContext.ArtPieces.OrderByDescending(ap => ap.Created).Skip(size * (page - 1)).Take(size).ToListAsync();
            double contentCount = await _dbContext.ArtPieces.CountAsync();
            int pageCount = (int)Math.Ceiling(contentCount / size);
            return new PaginatedResult<ArtPiece>(content, page, size, pageCount);
        }

        public async Task<ArtPiece> CreateArtPiece(string name, string authorId, int year, string description, MemoryStream file)
        {
            string base64Image = Convert.ToBase64String(file.ToArray());
            ArtPiece artPiece = new ArtPiece(name, authorId, year, description, base64Image);
            await _dbContext.AddAsync(artPiece);
            await _dbContext.SaveChangesAsync();
            return artPiece;
        }
        public async Task<ArtPiece> EditArtPiece(int artPieceId, string name, int year, string description, MemoryStream file)
        {
            ArtPiece artPiece = await _dbContext.ArtPieces.FindAsync(artPieceId);
            if (artPiece == null)
            {
                throw new ArgumentNullException();
            }
            artPiece.Name = name;
            artPiece.Year = year;
            artPiece.Description = description;
            if (file != null)
            {
                string base64Image = Convert.ToBase64String(file.ToArray());
                artPiece.Url = base64Image;
            }
            await _dbContext.SaveChangesAsync();
            return artPiece;
        }

        public async Task DeleteArtPiece(int artPieceId)
        {
            ArtPiece artPiece = await _dbContext.ArtPieces.FindAsync(artPieceId);
            if (artPiece == null)
            {
                throw new ArgumentNullException();
            }
            _dbContext.Remove(artPiece);
        }
    }
}
