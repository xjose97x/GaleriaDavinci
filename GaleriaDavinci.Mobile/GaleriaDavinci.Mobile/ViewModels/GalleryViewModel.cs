using GaleriaDavinci.Mobile.Services;
using Xamarin.Forms;

namespace GaleriaDavinci.Mobile.ViewModels
{
    public class GalleryViewModel : BaseViewModel
    {
        public IGalleryApiService GalleryApiService { get; }

        public GalleryViewModel()
        {
            Title = "Galeria Davinci";
            GalleryApiService = DependencyService.Get<IGalleryApiService>();
        }
    }
}
