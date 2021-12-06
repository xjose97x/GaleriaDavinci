using GaleriaDavinci.Domain.Models;
using GaleriaDavinci.Shared.Model;

namespace GaleriaDavinci.Web.ViewModels.Gallery
{
    public class GalleryViewModel
    {
        public PaginatedResult<ArtPiece> ArtPieces { get; set; }

        public GalleryViewModel(PaginatedResult<ArtPiece> artPieces)
        {
            ArtPieces = artPieces;
        }
    }
}
