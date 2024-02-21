using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Steganographysaurus.Core;
using Steganographysaurus.Infrastructure;
using System.Drawing;

namespace Steganographysaurus.WebApp.Pages
{
	public class DecodeModel : PageModel
	{
		[BindProperty]
        public string Password { get; set; }

		[BindProperty]
        public IFormFile StegoImage { get; set; }

        public string Message { get; set; }

        public SteganographyService	Service { get; set; }

        public DecodeModel(SteganographyService service)
		{
			Service = service;
		}

		public void OnPost()
		{
			using var stegoImage = new BitmapStegoImage(new Bitmap(StegoImage.OpenReadStream()));
			Message = Service.RevealMessage(Password, stegoImage);
		}
	}
}