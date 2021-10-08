using System;
using System.Collections.Generic;

namespace GaleriaDavinci.Domain.Models
{
    public class ArtPiece
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        public virtual IEnumerable<Review> Reviews { get; set; }
    }
}
