using GaleriaDavinci.Domain.Models;
using GaleriaDavinci.Models;
using GaleriaDavinci.Web.Interfaces;
using GaleriaDavinci.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GaleriaDavinci.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGalleryService _galleryService;

        public HomeController(ILogger<HomeController> logger, IGalleryService galleryService)
        {
            _logger = logger;
            _galleryService = galleryService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Privacy()
        {
            ArtPiece artPiece = await _galleryService.GetLastArtPiece();
            IEnumerable<Review> reviews = await _galleryService.GetReviewsByArtPiece(artPiece.ID);
            return View(new PrivacyViewModel(artPiece, reviews));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
