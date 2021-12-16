using GaleriaDavinci.Shared.Dto;
using GaleriaDavinci.UWP.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace GaleriaDavinci.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddArtPiece : Page
    {
        private readonly GalleryApiService _galleryApiService = new GalleryApiService();

        private StorageFile selectedImage;

        public AddArtPiece()
        {
            this.InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            App.TryGoBack();
        }

        private async void ImageSelectButton_Click(object sender, RoutedEventArgs e)
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker
            {
                ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail,
                SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.PicturesLibrary
            };
            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".jpeg");
            picker.FileTypeFilter.Add(".png");
            StorageFile file = await picker.PickSingleFileAsync();
            if (file == null)
            {
                return;
            }
            selectedImage = file;
            ImagePath.Text = file.Name;
            ImagePreview.Source = await Helpers.FileToBitMapImage(selectedImage);
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var authors = await _galleryApiService.GetAuthors();
            AuthorsComboBox.ItemsSource = new ObservableCollection<AuthorDto>(authors);
            AuthorsComboBox.DisplayMemberPath = "Name";
        }

        private async void Submit_Click(object sender, RoutedEventArgs e)
        {
            List<string> emptyFields = new List<string>();
            string name = NameInput.Text;
            AuthorDto author = AuthorsComboBox.SelectedItem as AuthorDto;
            double year = YearInput.Value;
            string description = DescriptionInput.Text;
            if (string.IsNullOrWhiteSpace(name))
            {
                emptyFields.Add("Nombre obra de arte");
            }
            if (author == null)
            {
                emptyFields.Add("Autor");
            }
            if (double.IsNaN(year))
            {
                emptyFields.Add("Año");
            }
            if (string.IsNullOrWhiteSpace(description))
            {
                emptyFields.Add("Descripcion");
            }
            if (selectedImage == null)
            {
                emptyFields.Add("Imagen");
            }
            if (emptyFields.Any())
            {
                StringBuilder message = new StringBuilder("Los siguientes campos se encuentran vacios:");
                foreach (var field in emptyFields)
                {
                    message.Append($"\n- {field}");
                }
                var errorDialog = new MessageDialog(message.ToString(), "Alerta");
                await errorDialog.ShowAsync();
                return;
            }
            using (var imageStream = await selectedImage.OpenStreamForReadAsync())
            {
                await _galleryApiService.CreateArtPiece(name, author.ID, Convert.ToInt32(year), description, imageStream);
            }
            var successDialog = new MessageDialog("Creado con exito!", "Alerta");
            await successDialog.ShowAsync();
            App.TryGoBack();
        }
    }
}
