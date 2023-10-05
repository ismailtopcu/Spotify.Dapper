using Microsoft.AspNetCore.Mvc;
using Spotify.Dapper.Services;
using System.Web.Mvc;

namespace Spotify.Dapper.ViewComponents
{
	public class Danceability : ViewComponent
	{
		private readonly ISpotifyDataService _spotifyDataService;

		public Danceability(ISpotifyDataService spotifyDataService)
		{
			_spotifyDataService = spotifyDataService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var values = await _spotifyDataService.GetTop5Danceability();
			var danceability = values.Select(x => x.Danceability).ToArray();
			var trackName = values.Select(x => x.track_name).ToArray();

			ViewBag.danceability = danceability;
			ViewBag.trackName = trackName;
			return View();
		}
	}
}
