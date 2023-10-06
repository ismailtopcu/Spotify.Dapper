using Microsoft.EntityFrameworkCore;
using Spotify.Dapper.DTO;

namespace Spotify.Dapper.Models
{
	public class AppDbContext:DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Data Source=ISMAIL\\SQLEXPRESS;Initial Catalog=SpotifyData;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<SpotifyData>().HasNoKey();
		}

		public DbSet<SpotifyData> SpotifyData{ get; set; }


    }
}
