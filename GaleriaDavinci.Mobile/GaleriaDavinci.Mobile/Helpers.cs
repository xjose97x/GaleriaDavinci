using System;
using System.IO;
using System.Linq;
using Xamarin.Forms;

namespace GaleriaDavinci.Mobile {
    class Helpers {
        public static ImageSource Base64ToImage(string base64) {
            var byteArray = Convert.FromBase64String(base64.Split(',').Last());
            return ImageSource.FromStream(() => new MemoryStream(byteArray));
        }
    }
}
