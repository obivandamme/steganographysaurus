// See https://aka.ms/new-console-template for more information
using Steganographysaurus.Infrastructure;
using Steganographysaurus.Core;

var source = "Data/steganographysaurus.png";
var target = "Data/steganographysaurus-hidden.png";
var repository = new BitmapStegoImageRepository();
var service = new SteganographyService(repository);

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
		message = $"{input}\x1A";

		Console.WriteLine("Enter a password to protect the message (optional):");
		pwd = Console.ReadLine() ?? "123456";

		Console.WriteLine("Hiding message...");
		service.HideMessage(message, pwd, source, target);
		Console.WriteLine("Done!");
		break;
	case "2":
		Console.WriteLine("Enter the password to reveal the message (optional):");
		pwd = Console.ReadLine() ?? "123456";
		Console.WriteLine("Revealing message...");
		message = service.RevealMessage(pwd, target);
		Console.WriteLine(message);
		break;
	default:
		Console.WriteLine("Invalid option");
		return;
}

Console.ReadLine();
