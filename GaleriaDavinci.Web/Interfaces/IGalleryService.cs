using GaleriaDavinci.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GaleriaDavinci.Web.Interfaces
{
    public interface IGalleryService
    {
        public Task<ArtPiece> GetArtPieceById(int id);
        public Task AddReview(int artPieceId, string authorName, int value, string comment);
        Task<IEnumerable<ArtPiece>> GetPaginatedArtPieces(int size, int page);
    }
}
