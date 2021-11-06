using Microsoft.AspNetCore.Http;

namespace GaleriaDavinci.Web.ViewModels.Author
{
    public class CreateArtPieceViewModel
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public IFormFile File { get; set; }
    }
}
