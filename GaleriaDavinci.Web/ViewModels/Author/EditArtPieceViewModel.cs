using Microsoft.AspNetCore.Http;

namespace GaleriaDavinci.Web.ViewModels.Author
{
    public class EditArtPieceViewModel
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public IFormFile File { get; set; }

        public EditArtPieceViewModel()
        {
        }

        public EditArtPieceViewModel(string name, int year, string description, string imageUrl)
        {
            Name = name;
            Year = year;
            Description = description;
            ImageUrl = imageUrl;
        }
    }
}
