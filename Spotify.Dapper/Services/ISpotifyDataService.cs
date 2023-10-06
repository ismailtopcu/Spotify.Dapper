using Spotify.Dapper.DTO;

namespace Spotify.Dapper.Services
{
    public interface ISpotifyDataService
	{
		Task<List<SpotifyData>> GetSpotifyDatas();
		Task<List<ResultGenreCountListDto>> GetGenreCountList();
		Task<List<ResultPopularityDto>> GetTop10PopularTrack();
		Task<List<ResultPopularArtistDto>> GetTop10PopularArtist();
		Task<List<SpotifyData>> GetSpotifyDatas(string searchTerm);
		Task<List<DanceabilityDto>> GetTop5Danceability();
		Task<List<ResultPopularArtistDto>> GetTop10TrackCount();
		Task<List<SpotifyData>> GetSpotifyDatasWithEf();
	}
}
