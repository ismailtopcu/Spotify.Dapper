using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Spotify.Dapper.Services;
using System.Diagnostics;
using System.Web.Helpers;

namespace Spotify.Dapper.ViewComponents
{
	public class PopularTrack :ViewComponent
	{
		private readonly ISpotifyDataService _spotifyDataService;

		public PopularTrack(ISpotifyDataService spotifyDataService)
		{
			_spotifyDataService = spotifyDataService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var values = await _spotifyDataService.GetTop10PopularTrack();
			var trackName = values.Select(x=>x.track_name).ToArray();
			var popularity = values.Select(x=> x.popularity).ToArray();
			var artistName = values.Select(x=>x.artist_name).ToArray();

			ViewBag.TrackName = trackName;
			ViewBag.Popularity = popularity;
			ViewBag.ArtistName = artistName;
			return View();
		}
	}
}
