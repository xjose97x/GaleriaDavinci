namespace GaleriaDavinci.Shared.Dto
{
    public class BuyArtPieceDto
    {
        public string BuyerEmail { get; set; }

        public BuyArtPieceDto() { }

        public BuyArtPieceDto(string buyerEmail)
        {
            BuyerEmail = buyerEmail;
        }
    }
}
