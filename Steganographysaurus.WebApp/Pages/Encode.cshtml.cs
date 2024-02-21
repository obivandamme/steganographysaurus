using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Steganographysaurus.Core;
using Steganographysaurus.WebApp.Models;
using System.Drawing;

namespace Steganographysaurus.WebApp.Pages
{
	public class EncodeModel : PageModel
	{
		[BindProperty]
		public IFormFile CoverImage { get; set; }

		[BindProperty]
        public string Message { get; set; }

		[BindProperty]
        public string Password { get; set; }

        public SteganographyService	Service { get; set; }

        public EncodeModel(SteganographyService service)
        {
            Service = service;
        }

        public ActionResult OnPost()
		{
			using var image = new FormFileStegoImage(CoverImage);
			Service.HideMessage(Message, Password, image);
			return File(image.ToByteArray(), "application/octet-stream", "stego-image.png");
		}
	}
}