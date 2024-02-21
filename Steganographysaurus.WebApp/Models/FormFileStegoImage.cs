using Steganographysaurus.Core;
using System.Drawing;

namespace Steganographysaurus.WebApp.Models
{
    public class FormFileStegoImage : IStegoImage
    {
        private Bitmap Bitmap { get; set; }
        public FormFileStegoImage(IFormFile formFile)
        {
            Bitmap = new Bitmap(formFile.OpenReadStream());
        }
        public int Width => Bitmap.Width;

        public int Height => Bitmap.Height;

        public void Dispose()
        {
            Bitmap.Dispose();
        }

        public Color GetPixel(int x, int y)
        {
            return Bitmap.GetPixel(x, y);
        }

        public void SetPixel(int x, int y, Color color)
        {
            Bitmap.SetPixel(x, y, color);
        }

        public byte[] ToByteArray()
        {
            return (byte[])new ImageConverter().ConvertTo(Bitmap, typeof(byte[]));
        }
    }
}
