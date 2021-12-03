using GaleriaDavinci.Shared.Dto;
using System;
using System.ComponentModel.DataAnnotations;

namespace GaleriaDavinci.Domain.Models
{
    public class Review : IAuditableEntity
    {
        public int ID { get; set; }

        public int ArtPieceId { get; set; }
        public virtual ArtPiece ArtPiece { get; set; }

        public string AuthorName { get; set; }

        [Range(1, 5)]
        public int Value { get; set; }
        public string Comment { get; set; }

        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        public Review() { }

        public Review(int artPieceId, string authorName, int value, string comment)
        {
            ArtPieceId = artPieceId;
            AuthorName = authorName;
            Value = value;
            Comment = comment;
        }

        public ReviewDto ConvertToDto()
        {
            return new ReviewDto(ID, ArtPieceId, AuthorName, Value, Comment, Created);
        }
    }
}
