using System;

namespace GaleriaDavinci.Shared.Dto
{
    public class ReviewDto
    {
        public int ID { get; set; }
        public int ArtPieceId { get; set; }
        public string AuthorName { get; set; }
        public int Value { get; set; }
        public string Comment { get; set; }
        public DateTime Created { get; set; }

        public ReviewDto(int id, int artPieceId, string authorName, int value, string comment, DateTime created)
        {
            ID = id;
            ArtPieceId = artPieceId;
            AuthorName = authorName;
            Value = value;
            Comment = comment;
            Created = created;
        }
    }
}
