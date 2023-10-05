using Microsoft.AspNetCore.Mvc;
using Spotify.Dapper.Services;

namespace Spotify.Dapper.ViewComponents
{
	public class PopularArtist : ViewComponent
	{
		private readonly ISpotifyDataService _spotifyDataService;

		public PopularArtist(ISpotifyDataService spotifyDataService)
		{
			_spotifyDataService = spotifyDataService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var values = await _spotifyDataService.GetTop10PopularArtist();
			var chartArtist = values.Select(x=>x.artist_name).ToArray();
			var chartCount = values.Select(x=>x.track_name).ToArray();

			ViewBag.Artist = chartArtist;
			ViewBag.Count = chartCount;
			return View();
		}
	}
}
