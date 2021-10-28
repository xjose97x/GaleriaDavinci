using GaleriaDavinci.Domain.Models;
using GaleriaDavinci.Web.Interfaces;
using GaleriaDavinci.Web.ViewModels.Gallery;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GaleriaDavinci.Web.Controllers
{
    public class GalleryController : Controller
    {
        private readonly IGalleryService _galleryService;

        public GalleryController(IGalleryService galleryService)
        {
            _galleryService = galleryService;
        }

        public async Task<IActionResult> Index([FromQuery] int page = 1, [FromQuery] int size = 5)
        {
            IEnumerable<ArtPiece> artPieces = await _galleryService.GetPaginatedArtPieces(size, page);
            return View(new GalleryViewModel(page, size, artPieces));
        }

        [HttpGet]
        public async Task<IActionResult> ArtPiece(int id)
        {
            ArtPiece artPiece = await _galleryService.GetArtPieceById(id);
            return View(new ArtPieceViewModel(artPiece));
        }

        [HttpPost]
        public async Task<IActionResult> ArtPiece(int id, ArtPieceViewModel model)
        {
            await _galleryService.AddReview(id, model.AuthorName, model.Value, model.Comment);
            return await ArtPiece(id);
        }
    }
}
