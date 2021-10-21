using GaleriaDavinci.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GaleriaDavinci.Web.Interfaces
{
    public interface IGalleryService
    {
        public void AddReview();
        Task<IEnumerable<ArtPiece>> GetPaginatedArtPieces(int size, int page);
    }
}
