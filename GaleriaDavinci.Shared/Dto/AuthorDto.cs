namespace GaleriaDavinci.Shared.Dto
{
    public class AuthorDto
    {
        public string ID { get; set; }
        public string Name { get; set; }

        public AuthorDto(string id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}
