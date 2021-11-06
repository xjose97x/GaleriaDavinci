using GaleriaDavinci.Domain.Models;
using GaleriaDavinci.Web.Interfaces;
using GaleriaDavinci.Web.ViewModels.Author;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace GaleriaDavinci.Web.Controllers
{
    [Authorize(Roles = SystemRoles.AUTHOR)]
    public class AuthorController : Controller
    {
        private readonly IGalleryService _galleryService;
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthorController(IGalleryService galleryService, UserManager<ApplicationUser> userManager)
        {
            _galleryService = galleryService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string userId = _userManager.GetUserId(User);
            return View(await _galleryService.GetArtPieceByAuthor(userId));
        }

        [HttpGet]
        public IActionResult CreateArtPiece()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateArtPiece(CreateArtPieceViewModel model)
        {
            string userId = _userManager.GetUserId(User);
            using (var fileStream = model.File.OpenReadStream())
            using(MemoryStream memoryStream = new MemoryStream())
            {
                await fileStream.CopyToAsync(memoryStream);
                await _galleryService.CreateArtPiece(model.Name, userId, model.Year, model.Description, memoryStream);
            }
            return RedirectToAction("Index", "Author");
        }

        [HttpGet]
        public async Task<IActionResult> EditArtPiece(int id)
        {
            ArtPiece artPiece = await _galleryService.GetArtPieceById(id);
            EditArtPieceViewModel model = new EditArtPieceViewModel(artPiece.Name, artPiece.Year, artPiece.Description, artPiece.Url);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditArtPiece(int id, EditArtPieceViewModel model)
        {
            string userId = _userManager.GetUserId(User);
            if (model.File != null)
            {
                using (var fileStream = model.File.OpenReadStream())
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    await fileStream.CopyToAsync(memoryStream);
                    await _galleryService.EditArtPiece(id, model.Name, model.Year, model.Description, memoryStream);
                }
            } else
            {
                await _galleryService.EditArtPiece(id, model.Name, model.Year, model.Description, null);
            }

            return RedirectToAction("Index", "Author");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteArtPiece(int id)
        {
            await _galleryService.DeleteArtPiece(id);
            return RedirectToAction("Index", "Author");
        }
    }
}
