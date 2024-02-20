using Steganographysaurus.Core;
using System.Drawing;

namespace Steganographysaurus.Infrastructure
{
	public class BitmapStegoImage : IStegoImage
	{
		private Bitmap Bitmap { get; set; }

		public BitmapStegoImage(string filename)
		{
			Bitmap = new Bitmap(filename);
		}

		public int Width => Bitmap.Width;

		public int Height => Bitmap.Height;

		public Color GetPixel(int x, int y)
		{
			return Bitmap.GetPixel(x, y);
		}

		public void SetPixel(int x, int y, Color color)
		{
			Bitmap.SetPixel(x, y, color);
		}
		public void Save(string filename)
		{
			Bitmap.Save(filename);
		}

		public void Dispose()
		{
			Bitmap.Dispose();
		}
	}
}
