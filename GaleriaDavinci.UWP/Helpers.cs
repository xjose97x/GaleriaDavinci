using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;
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

        public static async Task<BitmapImage> FileToBitMapImage(StorageFile file)
        {
            BitmapImage image = new BitmapImage();
            using (IRandomAccessStream fileStream = await file.OpenAsync(FileAccessMode.Read))
            {
                await image.SetSourceAsync(fileStream);
            }
            return image;
        }

        public static bool IsValidEmail(string email) {
            if (string.IsNullOrWhiteSpace(email) || !Regex.IsMatch(email, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")) {
                return false;
            }
            return true;
        }
        
}
}
