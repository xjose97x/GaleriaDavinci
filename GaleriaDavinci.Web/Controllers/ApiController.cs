using GaleriaDavinci.Shared.Dto;
using GaleriaDavinci.Shared.Model;
using GaleriaDavinci.Web.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GaleriaDavinci.Web.Controllers
{
    [Route("api")]
    [ApiController]
    public class ApiController : ControllerBase
    {

        private readonly IGalleryService _galleryService;
        private readonly IEmailService _emailService;

        public ApiController(IGalleryService galleryService, IEmailService emailService)
        {
            _galleryService = galleryService;
            _emailService = emailService;
        }

        // GET api/GalleryItems?size=6&page=1&search=mona
        [HttpGet("GalleryItems")]
        public async Task<ActionResult<PaginatedResult<ArtPieceDto>>> Get([FromQuery] int page = 1, [FromQuery] int size = 6, [FromQuery] string search = null)
        {
            var paginatedArtPieces = await _galleryService.GetPaginatedArtPieces(size, page, search);
            PaginatedResult<ArtPieceDto> result = new(
                paginatedArtPieces.Result.Select(ap => ap.ConvertToDto()),
                paginatedArtPieces.Page,
                paginatedArtPieces.Size,
                paginatedArtPieces.Search,
                paginatedArtPieces.PageCount
                );
            return result;
        }

        // GET api/5
        [HttpGet("GalleryItems/{id}")]
        public async Task<ActionResult<ArtPieceDto>> Get(int id)
        {
            var artPiece = await _galleryService.GetArtPieceById(id);
            if (artPiece == null)
            {
                return NotFound();
            }
            return artPiece.ConvertToDto();
        }

        // POST api
        [HttpPost("GalleryItems")]
        public async Task<ActionResult<int>> Post([FromForm]string name, [FromForm] string authorId, [FromForm] int year, [FromForm] string description, [FromForm] IFormFile file)
        {
            using var stream = new MemoryStream();
            await file.CopyToAsync(stream);
            var artPiece = await _galleryService.CreateArtPiece(name, authorId, year, description, stream);
            return artPiece.ID;
        }

        // PUT api/5
        [HttpPut("GalleryItems/{id}")]
        public async Task<IActionResult> Put(int id, [FromForm] string name, [FromForm] int year, [FromForm] string description, [FromForm] IFormFile file)
        {
            using var stream = new MemoryStream();
            if (file != null)
            {
                await file.CopyToAsync(stream);
            }
            await _galleryService.EditArtPiece(id, name, year, description, stream);
            return Ok();
        }

        // DELETE api/5
        [HttpDelete("GalleryItems/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _galleryService.DeleteArtPiece(id);
            return Ok();
        }

        // POST api/GalleryItems/1/Buy
        [HttpPost("GalleryItems/{id}/Buy")]
        public async Task<IActionResult> PostBuyForm(int id, [FromBody] BuyArtPieceDto dto)
        {
            var artPiece = await _galleryService.GetArtPieceById(id);
            if (artPiece == null)
            {
                return NotFound();
            }
            string subject = $"Proceso de compra de {artPiece.Name} ha inicializado";
            string content = $"Hola, te escribimos de Galeria Davinci para informarte que nos pondremos en contacto con el autor de la obra {artPiece.Name} para informale tu intencion de compra.\n ¡Gracias por preferirnos!";
            await _emailService.SendEmail(dto.BuyerEmail, subject, content);
            return Ok();
        }

        [HttpGet("Authors")]
        public async Task<ActionResult<IEnumerable<AuthorDto>>> GetAuthors()
        {
            var users = await _galleryService.GetAllUsers();
            return Ok(users.Select(u => new AuthorDto(u.Id, $"{u.FirstName} {u.LastName}")));
        }
    }
}
