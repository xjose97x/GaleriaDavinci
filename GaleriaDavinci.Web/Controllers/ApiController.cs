using GaleriaDavinci.Domain;
using GaleriaDavinci.Domain.Models;
using GaleriaDavinci.Web.Interfaces;
using GaleriaDavinci.Web.Models;
using GaleriaDavinci.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GaleriaDavinci.Web.Controllers {
    [Route("api")]
    [ApiController]
    public class ApiController : ControllerBase {

        private readonly IGalleryService _galleryService;
        private readonly IEmailService _emailService;

        public ApiController(IGalleryService galleryService, IEmailService emailService) {
            _galleryService = galleryService;
            _emailService = emailService;
        }

        // GET api/GalleryItems?size=6&page=1&search=mona
        [HttpGet("GalleryItems")]
        public async Task<ActionResult<PaginatedResult<ArtPiece>>> Get(int size, int page, string search = null) {
            return await _galleryService.GetPaginatedArtPieces(size, page, search);
        }

        // GET api/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArtPiece>> Get(int id) {
            return await _galleryService.GetArtPieceById(id);
        }

        // POST api
        [HttpPost]
        public void Post(string name, string authorId, int year, string description, MemoryStream file) {
            _galleryService.CreateArtPiece(name, authorId, year, description, file);
        }

        // PUT api/5
        [HttpPut("{id}")]
        public void Put(int id, string name, int year, string description, MemoryStream file) {
            _galleryService.EditArtPiece(id, name, year, description, file);
        }

        // DELETE api/5
        [HttpDelete("{id}")]
        public void Delete(int id) {
            _galleryService.DeleteArtPiece(id);
        }

        // POST api/sendEmail?to=christiansama1601@gmail.com&subject=hola&content=hola
        [HttpPost("sendEmail")]
        public void PostBuyForm(string to, string subject, string content) {
            _emailService.SendEmail(to, subject, content);
        }
    }
}
