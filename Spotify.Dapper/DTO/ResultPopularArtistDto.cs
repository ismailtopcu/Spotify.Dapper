using System.ComponentModel.DataAnnotations;

namespace Spotify.Dapper.DTO
{
	public class ResultPopularArtistDto
	{
		public string? artist_name { get; set; }
		public int? track_name { get; set; }
		public float? popularity { get; set; }
	}
}
