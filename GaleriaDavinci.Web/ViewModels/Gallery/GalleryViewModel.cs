using GaleriaDavinci.Domain.Models;
using System.Collections.Generic;

namespace GaleriaDavinci.Web.ViewModels.Gallery
{
    public class GalleryViewModel
    {
        public int Page { get; set; }
        public int Size { get; set; }
        public IEnumerable<ArtPiece> ArtPieces { get; set; }

        public GalleryViewModel(int page, int size, IEnumerable<ArtPiece> artPieces)
        {
            Page = page;
            Size = size;
            ArtPieces = artPieces;
        }
    }
}
