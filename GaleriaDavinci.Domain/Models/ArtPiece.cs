using GaleriaDavinci.Shared.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace GaleriaDavinci.Domain.Models
{
    public class ArtPiece : IAuditableEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }

        [ForeignKey("ApplicationUser")]
        public string AuthorId { get; set; }
        public virtual ApplicationUser Author { get; set; }

        public int Year { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        public virtual IEnumerable<Review> Reviews { get; set; }

        public ArtPiece() {}

        public ArtPiece(string name, string authorId, int year, string description, string url)
        {
            Name = name;
            AuthorId = authorId;
            Year = year;
            Description = description;
            Url = url;
        }


        public ArtPieceDto ConvertToDto()
        {
            return new ArtPieceDto(ID, Name, $"{Author.FirstName} {Author.LastName}", Year, Description, Url, Reviews.Select(r => r.ConvertToDto()));
        }
    }
}
