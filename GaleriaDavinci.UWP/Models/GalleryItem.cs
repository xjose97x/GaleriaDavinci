using GaleriaDavinci.Shared.Dto;
using Windows.UI.Xaml.Media.Imaging;

namespace GaleriaDavinci.UWP.Models
{
    public class GalleryItem : ArtPieceDto
    {
        public BitmapImage Bitmap { get; set; }
        public GalleryItem(ArtPieceDto artPieceDto, BitmapImage bitmapImage) : base(artPieceDto.ID, artPieceDto.Name, artPieceDto.AuthorName, artPieceDto.AuthorID, artPieceDto.Year, artPieceDto.Description, artPieceDto.Url, artPieceDto.Reviews)
        {
            Bitmap = bitmapImage;
        }
    }
}
