using GaleriaDavinci.Domain;
using GaleriaDavinci.Domain.Models;
using GaleriaDavinci.Shared.Model;
using GaleriaDavinci.Web.Interfaces;
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

        public async Task<PaginatedResult<ArtPiece>> GetPaginatedArtPieces(int size, int page, string search = null)
        {
            IQueryable<ArtPiece> query = _dbContext.ArtPieces;
            double contentCount = await _dbContext.ArtPieces.CountAsync();
            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(ap => ap.Name.Contains(search) || ap.Description.Contains(search) ||
                                                 ap.Year.ToString().Contains(search) || ap.Author.FirstName.Contains(search) ||
                                                 ap.Author.LastName.Contains(search));
                contentCount = await query.CountAsync();
            }
            var content =  await query.OrderByDescending(ap => ap.Created).Skip(size * (page - 1)).Take(size).ToListAsync();
            int pageCount = (int)Math.Ceiling(contentCount / size);
            return new PaginatedResult<ArtPiece>(content, page, size, search, pageCount);
        }

        public async Task<ArtPiece> CreateArtPiece(string name, string authorId, int year, string description, MemoryStream file)
        {
            ArtPiece artPiece = new ArtPiece(name, authorId, year, description, MemoryStreamToBase64Image(file));
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
            if (file != null && file.Length > 0)
            {
                artPiece.Url = MemoryStreamToBase64Image(file);
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
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        private string MemoryStreamToBase64Image(MemoryStream stream)
        {
            string base64Image = Convert.ToBase64String(stream.ToArray());
            base64Image = "data:image/png;base64," + base64Image;
            return base64Image;
        }
    }
}
