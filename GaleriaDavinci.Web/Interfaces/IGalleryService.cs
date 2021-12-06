using GaleriaDavinci.Domain.Models;
using GaleriaDavinci.Shared.Model;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace GaleriaDavinci.Web.Interfaces
{
    public interface IGalleryService
    {
        public Task<ArtPiece> GetArtPieceById(int id);
        public Task<IEnumerable<ArtPiece>> GetArtPieceByAuthor(string authorId);
        public Task AddReview(int artPieceId, string authorName, int value, string comment);
        Task<PaginatedResult<ArtPiece>> GetPaginatedArtPieces(int size, int page, string search = null);

        public Task<ArtPiece> CreateArtPiece(string name, string authorId, int year, string description, MemoryStream file);
        public Task<ArtPiece> EditArtPiece(int artPieceId, string name, int year, string description, MemoryStream file);
        public Task DeleteArtPiece(int artPieceId);
    }
}
