using GaleriaDavinci.Shared.Dto;
using GaleriaDavinci.UWP.Models;
using GaleriaDavinci.UWP.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.UI.Xaml;
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
        public int Page = 1;
        public int Size = 6;
        private GalleryApiService galleryApiService = new GalleryApiService();

        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var paginatedArtPieces = await galleryApiService.GetArtPieces();
            await RefreshGallery(paginatedArtPieces.Result);
        }

        private async void Search_Click(object sender, RoutedEventArgs e)
        {
            string searchValue = SearchInput.Text;
            var paginatedArtPieces = await galleryApiService.GetArtPieces(Page, Size, searchValue);
            await RefreshGallery(paginatedArtPieces.Result);
        }

        private async Task RefreshGallery(IEnumerable<ArtPieceDto> artPieces)
        {
            List<GalleryItem> galleryItems = new List<GalleryItem>();
            foreach (ArtPieceDto ap in artPieces)
            {
                BitmapImage image = await Helpers.Base64ToBitMapImage(ap.Url);
                galleryItems.Add(new GalleryItem(ap, image));
            }
            GridView.ItemsSource = galleryItems;
        }
    }
}
