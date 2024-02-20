namespace Steganographysaurus.Core
{
	public class Vector2
	{
		public int X { get; set; }
		public int Y { get; set; }

		public override string ToString()
		{
			return $"{X}:{Y}";
		}
	}
}
