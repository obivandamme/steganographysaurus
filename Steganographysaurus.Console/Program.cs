// See https://aka.ms/new-console-template for more information
using Steganographysaurus.Infrastructure;
using Steganographysaurus.Core;
using System.Drawing;

var source = "Data/steganographysaurus.png";
var target = "Data/steganographysaurus-hidden.png";
var service = new SteganographyService();

Console.WriteLine("Welcome to Steganographysaurus");
Console.WriteLine("Hiding and revealing messages in images");
Console.WriteLine("=======================================");
Console.WriteLine();
Console.WriteLine("Do you want to hide or reveal a message?");
Console.WriteLine("1. Hide");
Console.WriteLine("2. Reveal");

var option = Console.ReadLine();
string pwd;
string message;

switch (option)
{
	case "1":
		Console.WriteLine("Enter a message to hide in the image:");
		var input = Console.ReadLine();
		message = $"{input}";

		Console.WriteLine("Enter a password to protect the message (optional):");
		pwd = Console.ReadLine() ?? "123456";

		Console.WriteLine("Hiding message...");
		using (var image = new BitmapStegoImage(new Bitmap(source)))
		{
			service.HideMessage(message, pwd, image);
			image.Save(target);
			Console.WriteLine("Done!");
		} 
		break;
	case "2":
		Console.WriteLine("Enter the password to reveal the message (optional):");
		pwd = Console.ReadLine() ?? "123456";
		Console.WriteLine("Revealing message...");
		using (var image = new BitmapStegoImage(new Bitmap(target)))
		{
			message = service.RevealMessage(pwd, image);
			Console.WriteLine(message);
		}
		break;
	default:
		Console.WriteLine("Invalid option");
		return;
}

Console.ReadLine();
