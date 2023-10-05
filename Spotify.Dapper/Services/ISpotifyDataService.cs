using Spotify.Dapper.DTO;

namespace Spotify.Dapper.Services
{
    public interface ISpotifyDataService
	{
		Task<List<SpotifyDataDto>> GetSpotifyDatas();
		Task<List<ResultGenreCountListDto>> GetGenreCountList();
		Task<List<ResultPopularityDto>> GetTop10PopularTrack();
		Task<List<ResultPopularArtistDto>> GetTop10PopularArtist();
		Task<List<SpotifyDataDto>> GetSpotifyDatas(string searchTerm);
		Task<List<DanceabilityDto>> GetTop5Danceability();
		Task<List<ResultPopularArtistDto>> GetTop10TrackCount();
	}
}
