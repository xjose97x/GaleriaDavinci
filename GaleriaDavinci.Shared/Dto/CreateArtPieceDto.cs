using System;
using System.Collections.Generic;
using System.Text;

namespace GaleriaDavinci.Shared.Dto
{
    public class CreateArtPieceDto
    {
        public string Name { get; set; }
        public string AuthorId { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
    }
}
