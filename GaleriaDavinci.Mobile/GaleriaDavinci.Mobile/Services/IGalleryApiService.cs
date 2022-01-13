using GaleriaDavinci.Shared.Dto;
using GaleriaDavinci.Shared.Model;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace GaleriaDavinci.Mobile.Services
{
    public interface IGalleryApiService
    {
        Task<PaginatedResult<ArtPieceDto>> GetArtPieces(int page = 1, int size = 6, string search = null);
        Task<ArtPieceDto> GetArtPiece(int id);
        Task<int> CreateArtPiece(string name, string authorId, int year, string description, string imageName, Stream imageStream);
        Task EditArtPiece(int id, string name, string authorId, int year, string description, string imageName, Stream imageStream);
        Task DeleteArtPiece(int id);
        Task BuyArtPiece(int id, string buyerEmail);
        Task<IEnumerable<AuthorDto>> GetAuthors();
    }
}
