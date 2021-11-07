using GaleriaDavinci.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace GaleriaDavinci.Web.ViewModels.Gallery
{
    public class ArtPieceViewModel
    {
        public ArtPiece ArtPiece { get; set; }
        
        [Required]
        [Range(0, 5)]
        [Display(Name = "Puntuación")]
        public int Value { get; set; }
        
        [Required]
        [MaxLength(250)]
        [Display(Name = "Comentario")]
        public string Comment { get; set; }

        public ArtPieceViewModel() { }

        public ArtPieceViewModel(ArtPiece artPiece)
        {
            ArtPiece = artPiece;
        }
    }
}
