namespace Steganographysaurus.Core
{
	public class Vector3
	{
		public int R { get; set; }
		public int G { get; set; }
		public int B { get; set; }

		public void ForEach(Action<int> action)
		{
			action(R);
			action(G);
			action(B);
		}

		public override string ToString()
		{
			return $"{R}:{G}:{B}";
		}
	}
}
