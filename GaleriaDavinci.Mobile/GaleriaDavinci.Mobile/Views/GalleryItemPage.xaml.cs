using GaleriaDavinci.Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GaleriaDavinci.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [QueryProperty(nameof(ArtPieceId), "id")]
    public partial class GalleryItemPage : ContentPage
    {
        private GalleryItemViewModel _vm { get => BindingContext as GalleryItemViewModel; }
        public int ArtPieceId { get; set; }

        public GalleryItemPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            await _vm.LoadArtpiece(ArtPieceId);
            base.OnAppearing();
        }
    }
}