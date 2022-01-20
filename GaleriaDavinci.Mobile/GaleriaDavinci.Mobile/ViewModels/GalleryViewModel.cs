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
        
        public IGalleryApiService GalleryApiService { get; }

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
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
