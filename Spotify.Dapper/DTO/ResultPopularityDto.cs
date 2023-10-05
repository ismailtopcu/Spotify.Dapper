using System.ComponentModel.DataAnnotations;

namespace Spotify.Dapper.DTO
{
	public class ResultPopularityDto
	{
		public string? artist_name { get; set; }
		public string? track_name { get; set; }
		public float? popularity { get; set; }
	}
}
