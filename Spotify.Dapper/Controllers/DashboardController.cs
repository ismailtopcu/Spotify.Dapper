using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Spotify.Dapper.Services;
using System.Diagnostics;
using X.PagedList;

namespace Spotify.Dapper.Controllers
{
	public class DashboardController : Controller
	{
		private readonly ISpotifyDataService _spotifyDataService;

		public DashboardController(ISpotifyDataService spotifyDataService)
		{
			_spotifyDataService = spotifyDataService;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult TableDetails()
		{
			return View();
		}
		//public async Task<IActionResult> BigTable(int page = 1)
		//{
		//	var values = await _spotifyDataService.GetSpotifyDatas();
		//	return View(values.ToPagedList(page, 100));
		//}
		public async Task<IActionResult> GenreCountChart()
		{
			var values = await _spotifyDataService.GetGenreCountList();
			var labels = values.Select(v => v.Genre).ToArray();
			var data = values.Select(v => v.GenreCount).ToArray();

			ViewBag.ChartLabels = labels;
			ViewBag.ChartData = data;
			return View(values);
		}
		public async Task<IActionResult> BigTable(int page = 1, string searchTerm = "")
		{
			Stopwatch stopwatch = Stopwatch.StartNew();
			// Arama terimini kullanarak verileri çekin
			var values = await _spotifyDataService.GetSpotifyDatas(searchTerm);
			stopwatch.Stop();
			ViewBag.SearchTerm=searchTerm;
			ViewBag.Elapsed = ($"Sorgu süresi: {stopwatch.ElapsedMilliseconds} milisaniye");

			// Sonuçları sayfalandırın ve görünüme gönderin
			return View(values.ToPagedList(page, 1000));
		}
	}
}
