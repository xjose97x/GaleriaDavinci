using GaleriaDavinci.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace GaleriaDavinci.Mobile.Models {
    public class GalleryItem :ArtPieceDto{
        public Image Image { get; set; }

        public GalleryItem(ArtPieceDto artPieceDto, Image Image) : base(artPieceDto.ID, artPieceDto.Name, artPieceDto.AuthorName, artPieceDto.AuthorID, artPieceDto.Year, artPieceDto.Description, artPieceDto.Url, artPieceDto.Reviews) {
            this.Image = Image;
        }
    }
}
