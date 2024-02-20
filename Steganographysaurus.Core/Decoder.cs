using System.Text;

namespace Steganographysaurus.Core
{
	public class Decoder
	{
		private const string EOF = "\x1A";
		public bool IsEOF { get; private set; }
		public string Message { get; private set; }
		private int Buffer { get; set; }
		private int BitCounter { get; set; }

		public Decoder()
		{
			IsEOF = false;
			Message = string.Empty;
			Buffer = 0;
			BitCounter = 0;
		}

		public void Decode(Vector3 bits)
		{
			bits.ForEach(bit => DecodeBit(bit));
		}

		private void DecodeBit(int bit)
		{
			Buffer += bit << BitCounter;
			BitCounter++;
			if (BitCounter > 7)
			{
				DecodeBuffer();
			}
		}

		private void DecodeBuffer()
		{
			BitCounter = 0;
			var character = Encoding.ASCII.GetString(new[] { (byte)Buffer });
			if (character == EOF)
			{
				IsEOF = true;
				return;
			}
			Buffer = 0;
			Message += character;
		}
	}
}
