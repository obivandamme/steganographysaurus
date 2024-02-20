// See https://aka.ms/new-console-template for more information
using Steganographysaurus.Core;
using System.Collections;
using System.Drawing;
using System.Text;

static int CustomStringHash(string input)
{
	const int prime = 31;
	int hash = 0;

	foreach (char c in input)
	{
		hash = (hash * prime) + (int)c;
	}

	return hash;
}

static void HideMessage()
{
	Console.WriteLine("Hiding message...");

	var message = $"Hello World!\x1A";
	var messageBytes = Encoding.ASCII.GetBytes(message);
	var messageBits = new BitArray(messageBytes);

	while (messageBits.Length % 3 != 0)
	{
		messageBits.Length += 1;
	}

	var pwd = "123456789";
	var seed = CustomStringHash(pwd);
	var rng = new Random(seed);
	var usedPixels = new List<Vector2>();
	var image = new Bitmap(filename: "Data/steganographysaurus.png");
	var steganograph = new Steganograph(image);

	var bitsHidden = 0;
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

	image.Save("Data/steganographysaurus-hidden.png");

	Console.WriteLine("Done!");
}

static void ShowMessage()
{
	Console.WriteLine("Showing message...");

	var pwd = "123456789";
	var seed = CustomStringHash(pwd);
	var rng = new Random(seed);
	var usedPixels = new List<Vector2>();
	var image = new Bitmap(filename: "Data/steganographysaurus-hidden.png");
	var steanograph = new Steganograph(image);
	var decoder = new Steganographysaurus.Core.Decoder();

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

		var bits = steanograph.RevealBits(coordinates);

		decoder.Decode(bits);	
		usedPixels.Add(coordinates);
	}

	Console.WriteLine("Done!");
	Console.WriteLine(decoder.Message);
}

HideMessage();
ShowMessage();

Console.ReadLine();
