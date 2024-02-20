using Steganographysaurus.Core;

namespace Steganographysaurus.Console
{
	public class BitmapStegoImageRepository : IStegoRepository
	{
		public IStegoImage Load(string filename)
		{
			return new BitmapStegoImage(filename);
		}

		public void Save(string filename, IStegoImage image)
		{
			if(image is BitmapStegoImage)
			{
				((BitmapStegoImage)image).Bitmap.Save(filename);
			}
			else
			{
				throw new ArgumentException("Image type not supported");
			}
		}
	}
}
