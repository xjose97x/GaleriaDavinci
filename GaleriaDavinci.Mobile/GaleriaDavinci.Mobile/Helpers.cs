using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GaleriaDavinci.Mobile {
    class Helpers {
        public static Image Base64ToImage(string base64) {

            var byteArray = Convert.FromBase64String(base64.Split(',').Last());
            Stream stream = new MemoryStream(byteArray);
            Image image = new Image() {
                Source = ImageSource.FromStream(() => stream)
            };
            return image;
        }
    }
}
