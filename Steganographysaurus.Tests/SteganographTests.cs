using Steganographysaurus.Core;
using System.Drawing;

namespace Steganographysaurus.Tests
{
	public class SteganographTests
	{
		[TestCase(0, 0, 0)]
		[TestCase(1, 0, 0)]
		[TestCase(0, 1, 0)]
		[TestCase(0, 0, 1)]
		[TestCase(1, 1, 1)]
		public void ShouldHidePixels(int r, int g, int b)
		{
			var stegoImageName = $"steganographysaurus_hidden_{r}{g}{b}.png";
			var coverImage = new Bitmap("Data/steganographysaurus.png");
			var steganograph = new Steganograph(coverImage);

			steganograph.HideBits(new Vector2 { X = 0, Y = 0 }, new Vector3 { R = r, G = g, B = b });
			steganograph.Image.Save(stegoImageName);

			using (var stegoImage = new Bitmap(stegoImageName))
			{
				var hiddenSteganograph = new Steganograph(stegoImage);
				var bits = hiddenSteganograph.RevealBits(new Vector2 { X = 0, Y = 0 });

				Assert.AreEqual(r, bits.R);
				Assert.AreEqual(g, bits.G);
				Assert.AreEqual(b, bits.B);
			}

			File.Delete(stegoImageName);
		}
	}
}