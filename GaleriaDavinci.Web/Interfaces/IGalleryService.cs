using GaleriaDavinci.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GaleriaDavinci.Web.Interfaces
{
    public interface IGalleryService
    {
        public void AddReview();

        public Task<ArtPiece> GetLastArtPiece();
        public Task<IEnumerable<Review>> GetReviewsByArtPiece(int artPieceId);
    }
}
