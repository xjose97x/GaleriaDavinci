using System.Collections.Generic;

namespace GaleriaDavinci.Shared.Dto
{
    public class ArtPieceDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string AuthorName { get; set; }
        public string AuthorID { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }

        public IEnumerable<ReviewDto> Reviews { get; set; }

        public ArtPieceDto(int id, string name, string authorName, string authorID, int year, string description, string url, IEnumerable<ReviewDto> reviews)
        {
            ID = id;
            Name = name;
            AuthorName= authorName;
            AuthorID = authorID;
            Year = year;
            Description = description;
            Url = url;
            Reviews = reviews;
        }
    }
}
