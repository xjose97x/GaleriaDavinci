using GaleriaDavinci.Mobile.Models;
using GaleriaDavinci.Mobile.Services;
using GaleriaDavinci.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GaleriaDavinci.Mobile.ViewModels {
    public class GalleryViewModel : INotifyPropertyChanged {
        public int Page = 1;
        public int Size = 6;
        
        public IGalleryApiService GalleryApiService { get; }

        private readonly IList<GalleryItem> source;

        string title = string.Empty;
        public string Title {
            get => title;
            set {
                if (title != value) {
                    title = value;
                    OnPropertyChanged(nameof(Title));
                }
            }
        }

        ObservableCollection<GalleryItem> galleryItems;
        public ObservableCollection<GalleryItem> GalleryItems {
            get => galleryItems;
            set {
                if (galleryItems != value) {
                    galleryItems = value;
                    OnPropertyChanged(nameof(GalleryItems));
                }
            }
        }

        public GalleryViewModel() {
            GalleryApiService = DependencyService.Get<IGalleryApiService>();
            Title = "Galeria Davinci";

            source = new List<GalleryItem>();
            PopulateGalleryItemCollection();
        }

        private async void PopulateGalleryItemCollection(string search = null) {

            var paginatedArtPieces = await GalleryApiService.GetArtPieces(Page, Size, search);

            foreach (ArtPieceDto ap in paginatedArtPieces.Result) {
                source.Add(new GalleryItem(ap, Helpers.Base64ToImage(ap.Url)));
            }

            galleryItems = new ObservableCollection<GalleryItem>(source);
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
