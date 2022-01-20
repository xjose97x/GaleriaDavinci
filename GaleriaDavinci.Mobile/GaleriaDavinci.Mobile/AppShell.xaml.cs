using GaleriaDavinci.Mobile.Views;
using Xamarin.Forms;

namespace GaleriaDavinci.Mobile
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(GalleryItemPage), typeof(GalleryItemPage));
        }
    }
}
