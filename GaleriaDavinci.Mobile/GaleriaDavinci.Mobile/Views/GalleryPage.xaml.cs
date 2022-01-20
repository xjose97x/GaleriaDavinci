using GaleriaDavinci.Mobile.Models;
using GaleriaDavinci.Mobile.Services;
using GaleriaDavinci.Mobile.ViewModels;
using GaleriaDavinci.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GaleriaDavinci.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GalleryPage : ContentPage
    {
        public int Page = 1;
        public int Size = 6;
        private readonly GalleryViewModel _vm;

        public GalleryPage()
        {
            InitializeComponent();
            _vm = BindingContext as GalleryViewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await RefreshGallery();
        }

        private async Task RefreshGallery(string search = null)
        {
            var paginatedArtPieces = await _vm.GalleryApiService.GetArtPieces(Page, Size, search);
            var source = new List<GalleryItem>();
            foreach (ArtPieceDto ap in paginatedArtPieces.Result)
            {
                source.Add(new GalleryItem(ap, Helpers.Base64ToImage(ap.Url)));
            }
            _vm.GalleryItems = new ObservableCollection<GalleryItem>(source);
        }
    }
}