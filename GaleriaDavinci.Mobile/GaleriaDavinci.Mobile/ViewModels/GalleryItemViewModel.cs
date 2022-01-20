using GaleriaDavinci.Mobile.Services;
using GaleriaDavinci.Shared.Dto;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GaleriaDavinci.Mobile.ViewModels
{
    public class GalleryItemViewModel : INotifyPropertyChanged
    {
        public IGalleryApiService GalleryApiService { get; }

        string title = string.Empty;
        public string Title
        {
            get => title;
            set
            {
                if (title != value)
                {
                    title = value;
                    OnPropertyChanged(nameof(Title));
                }
            }
        }

        ArtPieceDto artPieceDto;
        public ArtPieceDto ArtPieceDto
        {
            get => artPieceDto;
            set
            {
                if (artPieceDto != value)
                {
                    artPieceDto = value;
                    Title = artPieceDto.Name;
                    OnPropertyChanged(nameof(ArtPieceDto));
                }
            }
        }

        public async Task LoadArtpiece(int artPieceId)
        {
            ArtPieceDto = await GalleryApiService.GetArtPiece(artPieceId);
        }

        public GalleryItemViewModel()
        {
            GalleryApiService = DependencyService.Get<IGalleryApiService>();
            Title = "Detalle obra";
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
