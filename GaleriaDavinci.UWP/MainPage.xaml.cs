using GaleriaDavinci.Shared.Dto;
using GaleriaDavinci.UWP.Models;
using GaleriaDavinci.UWP.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace GaleriaDavinci.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public ObservableCollection<GalleryItem> ObservableGalleryItems;
        
        private GalleryApiService galleryApiService = new GalleryApiService();

        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var paginatedArtPieces = await galleryApiService.GetArtPieces();
            List<GalleryItem> galleryItems = new List<GalleryItem>();
            foreach(var ap in paginatedArtPieces.Result)
            {
                BitmapImage image = await Helpers.Base64ToBitMapImage(ap.Url);
                galleryItems.Add(new GalleryItem(ap, image));
            }
            ObservableGalleryItems = new ObservableCollection<GalleryItem>(galleryItems);
            GridView.ItemsSource = ObservableGalleryItems;
        }
    }
}
