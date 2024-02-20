using System.Drawing;

namespace Steganographysaurus.Core
{
	public class Steganograph
	{
		public IStegoImage Image { get; }
		public Steganograph(IStegoImage image)
		{
			Image = image;
		}

		public void HideBits(Vector2 coordinates, Vector3 bits)
		{
			var pixel = Image.GetPixel(coordinates.X, coordinates.Y);
			var r = pixel.R;
			var g = pixel.G;
			var b = pixel.B;

			r = (byte)((r & 0b11111110) | bits.R);
			g = (byte)((g & 0b11111110) | bits.G);
			b = (byte)((b & 0b11111110) | bits.B);

			Image.SetPixel(coordinates.X, coordinates.Y, Color.FromArgb(r, g, b));
		}

		public Vector3 RevealBits(Vector2 coordinates)
		{
			var pixel = Image.GetPixel(coordinates.X, coordinates.Y);

			var r = pixel.R & 0b00000001;
			var g = pixel.G & 0b00000001;
			var b = pixel.B & 0b00000001;

			return new Vector3
			{
				R = r,
				B = b,
				G = g
			};
		}
	}
}