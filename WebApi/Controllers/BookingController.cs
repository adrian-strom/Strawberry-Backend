using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class BookingController : ControllerBase
	{
		public BookingController()
		{
		}

		[HttpPost]
		public bool Book()
		{
			return true;
		}
	}
}