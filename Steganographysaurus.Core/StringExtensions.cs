namespace Steganographysaurus.Core
{
	public static class StringExtensions
	{
		public static int GetStaticHashCode(this string input)
		{
			const int prime = 31;
			int hash = 0;

			foreach (char c in input)
			{
				hash = (hash * prime) + c;
			}

			return hash;
		}
	}
}
