using System.ComponentModel.DataAnnotations;

namespace Spotify.Dapper.DTO
{
    public class SpotifyDataDto
    {
        public float? F1 { get; set; }
        [MaxLength(255)]
        public string? artist_name { get; set; }
        [MaxLength(255)]
        public string? track_name { get; set; }
        [MaxLength(255)]
        public string? track_id { get; set; }
        public float? popularity { get; set; }
        public float? year { get; set; }
        [MaxLength(255)]
        public string? genre { get; set; }
        public float? danceability { get; set; }
        public float? energy { get; set; }
        public float? key { get; set; }
        public float? loudness { get; set; }
        public float? mode { get; set; }
        public float? speechiness { get; set; }
        public float? acousticness { get; set; }
        public float? instrumentalness { get; set; }
        public float? liveness { get; set; }
        public float? valence { get; set; }
        public float? tempo { get; set; }
        public float? duration_ms { get; set; }
        public float? time_signature { get; set; }
    }
}
