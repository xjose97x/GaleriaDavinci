using GaleriaDavinci.Domain.Models;
using GaleriaDavinci.Web.Models;

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
