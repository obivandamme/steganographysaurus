using System.Collections;
using System.Text;

namespace Steganographysaurus.Core
{
	public class SteganographyService
	{
		public IStegoRepository Repository { get; set; }
		public SteganographyService(IStegoRepository repository)
		{
			Repository = repository;
		}

		public void HideMessage(string message, string password, string source, string target)
		{
			var messageBytes = Encoding.ASCII.GetBytes(message);
			var messageBits = new BitArray(messageBytes);

			while (messageBits.Length % 3 != 0)
			{
				messageBits.Length += 1;
			}

			using var image = Repository.Load(source);
			var steganograph = new Steganograph(image);

			var bitsHidden = 0;
			var rng = new Random(password.GetStaticHashCode());
			var usedPixels = new List<Vector2>();
			while (bitsHidden < messageBits.Length)
			{
				var coordinates = new Vector2
				{
					X = rng.Next(image.Width),
					Y = rng.Next(image.Height)
				};

				if (usedPixels.Contains(coordinates))
				{
					continue;
				}

				var bits = new Vector3
				{
					R = messageBits[bitsHidden] ? 1 : 0,
					G = messageBits[bitsHidden + 1] ? 1 : 0,
					B = messageBits[bitsHidden + 2] ? 1 : 0
				};

				steganograph.HideBits(coordinates, bits);

				usedPixels.Add(coordinates);
				bitsHidden += 3;
			}

			Repository.Save(target, image);
		}

		public string RevealMessage(string password, string filename)
		{
			using var image = Repository.Load(filename);
			var steganograph = new Steganograph(image);

			var decoder = new Decoder();
			var rng = new Random(password.GetStaticHashCode());
			var usedPixels = new List<Vector2>();
			while (decoder.IsEOF == false)
			{
				var coordinates = new Vector2
				{
					X = rng.Next(image.Width),
					Y = rng.Next(image.Height)
				};


				if (usedPixels.Contains(coordinates))
				{
					continue;
				}

				var bits = steganograph.RevealBits(coordinates);

				decoder.Decode(bits);
				usedPixels.Add(coordinates);
			}

			return decoder.Message;
		}	
	}
}
