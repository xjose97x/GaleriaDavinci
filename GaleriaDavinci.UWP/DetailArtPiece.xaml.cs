using GaleriaDavinci.Shared.Dto;
using GaleriaDavinci.UWP.Models;
using GaleriaDavinci.UWP.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace GaleriaDavinci.UWP {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DetailArtPiece : Page {

        private GalleryItem galleryItem;
        private ArtPieceDto artPiece;
        private ObservableCollection<ReviewDto> reviews;
        private GalleryApiService galleryApiService = new GalleryApiService();

        public DetailArtPiece() {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e) {

            galleryItem = e.Parameter as GalleryItem;

            artPiece = await galleryApiService.GetArtPiece(galleryItem.ID);
            artPieceImage.Source = await Helpers.Base64ToBitMapImage(artPiece.Url);

            artPieceName.Text = artPiece.Name;
            artPieceDescription.Text = artPiece.Description;
            reviews = new ObservableCollection<ReviewDto>(artPiece.Reviews);
            reviewsListView.ItemsSource = reviews;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e) {
            App.TryGoBack();
        }

        private async void buyButton_Click(object sender, RoutedEventArgs e) {

            string email = buyerEmailTextBox.Text;

            if (!Helpers.IsValidEmail(email)) {
                emailFlyout.ShowAt(buyerEmailTextBox);
                return;
            }
            await galleryApiService.BuyArtPiece(artPiece.ID, email);
        }
    }
}
