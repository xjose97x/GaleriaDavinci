using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace GaleriaDavinci.UWP
{
    public static class Helpers
    {
        public static async Task<BitmapImage> Base64ToBitMapImage(string base64)
        {
            byte[] bytes = Convert.FromBase64String(base64.Split(",").Last());
            BitmapImage image = new BitmapImage();
            using (MemoryStream stream = new MemoryStream(bytes))
            {
                await image.SetSourceAsync(stream.AsRandomAccessStream());
            }
            return image;
        }
    }
}
