﻿using GaleriaDavinci.Domain.Models;
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

        public async Task<IActionResult> Index()
        {
            int page = 1;
            int size = 5;
            IEnumerable<ArtPiece> artPieces = await _galleryService.GetPaginatedArtPieces(size, page);
            return View(new GalleryViewModel(page, size, artPieces));
        }
    }
}
