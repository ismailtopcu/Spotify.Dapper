using Microsoft.AspNetCore.Mvc;
using Spotify.Dapper.Services;
using System.Web.Mvc;

namespace Spotify.Dapper.ViewComponents
{
	public class TrackCount : ViewComponent
	{
		private readonly ISpotifyDataService _spotifyDataService;

		public TrackCount(ISpotifyDataService spotifyDataService)
		{
			_spotifyDataService = spotifyDataService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var values = await _spotifyDataService.GetTop10TrackCount();
			var track_name = values.Select(x => x.track_name).ToArray();
			var artist_name = values.Select(x => x.artist_name).ToArray();

			ViewBag.track_name = track_name;
			ViewBag.artist_name = artist_name;
			return View();
		}
	}
}
