using GaleriaDavinci.Mobile.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace GaleriaDavinci.Mobile.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}