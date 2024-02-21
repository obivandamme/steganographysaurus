
using Steganographysaurus.Core;
using Steganographysaurus.Infrastructure;
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

			var target = $"steganographysaurus_hidden_{r}{g}{b}.png";
			var source = "Data/steganographysaurus.png";
			var coverImage = new BitmapStegoImage(new Bitmap(source));
			var steganograph = new Steganograph(coverImage);

			steganograph.HideBits(new Vector2 { X = 0, Y = 0 }, new Vector3 { R = r, G = g, B = b });
			coverImage.Save(target);

			using (var stegoImage = new BitmapStegoImage(new Bitmap(target)))
			{
				var hiddenSteganograph = new Steganograph(stegoImage);
				var bits = hiddenSteganograph.RevealBits(new Vector2 { X = 0, Y = 0 });

				Assert.AreEqual(r, bits.R);
				Assert.AreEqual(g, bits.G);
				Assert.AreEqual(b, bits.B);
			}

			File.Delete(target);
		}
	}
}