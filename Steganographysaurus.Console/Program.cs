// See https://aka.ms/new-console-template for more information
using Steganographysaurus.Infrastructure;
using Steganographysaurus.Core;

var message = $"Hello World!\x1A";
var pwd = "123456789";
var source = "Data/steganographysaurus.png";
var target = "Data/steganographysaurus-hidden.png";

var repository = new BitmapStegoImageRepository();
var service = new SteganographyService(repository);

Console.WriteLine("Hiding message...");
service.HideMessage(message, pwd, source, target);
Console.WriteLine("Done!");

Console.WriteLine("Revealing message...");
var revealedMessage = service.RevealMessage(pwd, target);
Console.WriteLine("Done!");

Console.WriteLine(revealedMessage);
Console.ReadLine();
