using System;
using System.ComponentModel.DataAnnotations;

namespace GaleriaDavinci.Domain.Models
{
    public class Review
    {
        public int ID { get; set; }

        public int ArtPieceId { get; set; }
        public virtual ArtPiece ArtPiece { get; set; }

        [Range(1, 5)]
        public int Value { get; set; }
        public string Comment { get; set; }
    }
}
