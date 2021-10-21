using GaleriaDavinci.Domain.Models;
using System;
using System.Collections.Generic;

namespace GaleriaDavinci.Web.ViewModels
{
    public class PrivacyViewModel
    {
        public DateTime Now { get; set; }
        public ArtPiece LastArtPiece { get; set; }
        public IEnumerable<Review> Reviews { get; set; }

        public PrivacyViewModel(ArtPiece lastArtPiece, IEnumerable<Review> reviews)
        {
            Now = DateTime.Now;
            LastArtPiece = lastArtPiece;
            Reviews = reviews;
        }
    }
}
