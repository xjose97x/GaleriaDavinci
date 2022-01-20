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
        //private readonly IGalleryApiService _galleryApiService;

        public GalleryPage()
        {
            InitializeComponent();
            //GalleryViewModel vm = BindingContext as GalleryViewModel;
            //_galleryApiService = vm.GalleryApiService;
        }

        //protected override async void OnAppearing() {
        //    base.OnAppearing();
        //    await RefreshGallery();
        //}

        //private async Task RefreshGallery(string search = null) {

        //    flexLayout.Children.Clear();

        //    var paginatedArtPieces = await _galleryApiService.GetArtPieces(Page, Size, search);

        //    foreach (ArtPieceDto ap in paginatedArtPieces.Result) {
        //        //Convert base64 to Stream
        //        var byteArray = Convert.FromBase64String(ap.Url.Split(',').Last());
        //        Stream stream = new MemoryStream(byteArray);

        //        Image image = new Image() {
        //            Source = ImageSource.FromStream(() => stream),
        //            WidthRequest = 200,
        //            HeightRequest = 200
        //        };

        //        flexLayout.Children.Add(image);
        //    }

        //}

    }


}