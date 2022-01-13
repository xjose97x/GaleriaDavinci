using GaleriaDavinci.Mobile.Services;
using GaleriaDavinci.Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GaleriaDavinci.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GalleryPage : ContentPage
    {
        private readonly IGalleryApiService _galleryApiService;

        public GalleryPage()
        {
            InitializeComponent();
            GalleryViewModel vm = BindingContext as GalleryViewModel;
            _galleryApiService = vm.GalleryApiService;
        }

        protected override async void OnAppearing()
        {
            var x = await _galleryApiService.GetArtPieces();
            base.OnAppearing();
        }
    }
}