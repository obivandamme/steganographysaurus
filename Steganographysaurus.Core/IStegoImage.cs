﻿using System.Drawing;

namespace Steganographysaurus.Core
{
	public interface IStegoImage
	{
		Color GetPixel(int x, int y);
		void SetPixel(int x, int y, Color color);
		int Width { get; }
		int Height { get; }
	}
}
