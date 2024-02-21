using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Steganographysaurus.Core;
using Steganographysaurus.WebApp.Models;

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
			Message = Service.RevealMessage(Password, new FormFileStegoImage(StegoImage));
		}
	}
}