using GaleriaDavinci.Mobile.Services;
using GaleriaDavinci.Shared.Dto;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GaleriaDavinci.Mobile.ViewModels
{
    public class GalleryItemViewModel : INotifyPropertyChanged
    {
        public IGalleryApiService GalleryApiService { get; }

        ArtPieceDto artPieceDto;
        public ArtPieceDto ArtPieceDto {
            get => artPieceDto;
            set {
                if (artPieceDto != value) {
                    artPieceDto = value;
                    OnPropertyChanged(nameof(ArtPieceDto));
                }
            }
        }

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

        ImageSource artPieceImage;
        public ImageSource ArtPieceImage {
            get => artPieceImage;
            set {
                if (artPieceImage != value) {
                    artPieceImage = value;
                    OnPropertyChanged(nameof(ArtPieceImage));
                }
            }
        }

        string description = string.Empty;
        public string Description {
            get => description;
            set {
                if (description != value) {
                    description = value;
                    OnPropertyChanged(nameof(Description));
                }
            }
        }

        string author;
        public string Author {
            get => author;
            set {
                if (author != value) {
                    author = value;
                    OnPropertyChanged(nameof(Author));
                }
            }
        }

        int year;
        public int Year {
            get => year;
            set {
                if (year != value) {
                    year = value;
                    OnPropertyChanged(nameof(Year));
                }
            }
        }

        ObservableCollection<ReviewDto> reviews;

        public ObservableCollection<ReviewDto> Reviews {
            get => reviews;
            set {
                if (reviews != value) {
                    reviews = value;
                    OnPropertyChanged(nameof(Reviews));
                }
            }
        }

        public async Task LoadArtpiece(int artPieceId) {
            ArtPieceDto = await GalleryApiService.GetArtPiece(artPieceId);
            Title = artPieceDto.Name;
            ArtPieceImage = Helpers.Base64ToImage(artPieceDto.Url);
            Description = artPieceDto.Description;
            Author = artPieceDto.AuthorName;
            Year = artPieceDto.Year;
            Reviews = new ObservableCollection<ReviewDto>(artPieceDto.Reviews);
            int x = 1;
        }

        public GalleryItemViewModel()
        {
            GalleryApiService = DependencyService.Get<IGalleryApiService>();
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
