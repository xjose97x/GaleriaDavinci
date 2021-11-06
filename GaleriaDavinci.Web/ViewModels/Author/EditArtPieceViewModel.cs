using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GaleriaDavinci.Web.ViewModels.Author
{
    public class EditArtPieceViewModel
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public IFormFile File { get; set; }
    }
}
