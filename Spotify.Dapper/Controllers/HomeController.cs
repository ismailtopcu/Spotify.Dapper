using Microsoft.AspNetCore.Mvc;
using Spotify.Dapper.Models;
using Spotify.Dapper.Services;
using System.Diagnostics;
using X.PagedList;

namespace Spotify.Dapper.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly ISpotifyDataService _spotifyDataService;

		public HomeController(ILogger<HomeController> logger, ISpotifyDataService spotifyDataService)
		{
			_logger = logger;
			_spotifyDataService = spotifyDataService;
		}

		public async Task<IActionResult> Index(int page = 1)
		{
			var values = await _spotifyDataService.GetSpotifyDatas();
			return View(values.ToPagedList(page, 100));
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}