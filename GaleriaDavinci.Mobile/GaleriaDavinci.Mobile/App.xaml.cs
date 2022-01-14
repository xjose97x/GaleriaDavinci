using GaleriaDavinci.Mobile.Services;
using Xamarin.Forms;

namespace GaleriaDavinci.Mobile
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            DependencyService.Register<MockDataStore>();
            DependencyService.Register<IGalleryApiService, GalleryApiService>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
