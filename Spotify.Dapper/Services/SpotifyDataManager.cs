using Dapper;
using Microsoft.Data.SqlClient;
using Spotify.Dapper.DTO;

namespace Spotify.Dapper.Services
{
    public class SpotifyDataManager : ISpotifyDataService
	{
		private readonly string _connectionString = "Data Source=ISMAIL\\SQLEXPRESS;Initial Catalog=SpotifyData;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

		public async Task<List<ResultGenreCountListDto>> GetGenreCountList()
		{
			using var connection = new SqlConnection(_connectionString);
			connection.Open();
			var results = await connection.QueryAsync<ResultGenreCountListDto>("SELECT genre, COUNT(*) AS GenreCount FROM SpotifyData GROUP BY genre");
			return results.ToList();
		}

		public async Task<List<SpotifyDataDto>> GetSpotifyDatas()
		{
			using var connection = new SqlConnection(_connectionString);
			connection.Open();
			var results = await connection.QueryAsync<SpotifyDataDto>("select * from SpotifyData");

			return results.ToList();
		}

		public async Task<List<SpotifyDataDto>> GetSpotifyDatas(string searchTerm)
		{
			using var connection = new SqlConnection(_connectionString);
			connection.Open();
			string sql = "SELECT * FROM SpotifyData";
			if (!string.IsNullOrEmpty(searchTerm))
			{
				// İlk koşulu ekliyoruz
				sql += " WHERE ";

				for (int i = 1; i <= searchTerm.Length; i++)
				{
					if (i == 1)
					{
						sql += " (track_id = @SearchTerm OR LEFT(track_name, 1) = @SearchTerm OR LEFT(artist_name, 1) = @SearchTerm)";
					}
					else
					{
						sql += $" OR (track_id = @SearchTerm OR LEFT(track_name, {i}) = @SearchTerm OR LEFT(artist_name, {i}) = @SearchTerm)";
					}
				}
			}
			var results = await connection.QueryAsync<SpotifyDataDto>(sql, new { SearchTerm = searchTerm });
			return results.ToList();
		}



		public async Task<List<ResultPopularityDto>> GetTop10PopularTrack()
		{
			using var connection = new SqlConnection(_connectionString);
			connection.Open();
			var result = await connection.QueryAsync<ResultPopularityDto>("select top 10 artist_name,track_name,popularity from SpotifyData order by popularity desc");
			return result.ToList();
		}

		public async Task<List<ResultPopularArtistDto>> GetTop10PopularArtist()
		{
			using var connection = new SqlConnection(_connectionString);
			connection.Open();
			var result = await connection.QueryAsync<ResultPopularArtistDto>("select Top 10 artist_name,Count(*) as track_name from SpotifyData where popularity>=60\r\ngroup by artist_name order by track_name desc");
			return result.ToList();
		}

		public async Task<List<DanceabilityDto>> GetTop5Danceability()
		{
			using var connection = new SqlConnection(_connectionString);
			connection.Open();
			var result = await connection.QueryAsync<DanceabilityDto>("select top 5 track_name,danceability from SpotifyData order by popularity desc");
			return result.ToList();
		}

		public async Task<List<ResultPopularArtistDto>> GetTop10TrackCount()
		{
			using var connection = new SqlConnection(_connectionString);
			connection.Open();
			var result = await connection.QueryAsync<ResultPopularArtistDto>("select top 10 Count(*) as track_name, artist_name from SpotifyData group by artist_name order by  track_name desc");
			return result.ToList();
		}
	}
	
}
