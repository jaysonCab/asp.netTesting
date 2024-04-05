using animeRanking.Entities;
using Microsoft.EntityFrameworkCore;

namespace animeRanking.Data;

public class AnimeContext(DbContextOptions<AnimeContext> options) : DbContext(options)
{
  public DbSet<Anime> Anime => Set<Anime>();
  public DbSet<Genre> Genres => Set<Genre>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>().HasData(
          new {Id = 1, Name = "Drama"},
          new {Id = 2, Name = "Fantasy"},
          new {Id = 3, Name = "Romance"}
        );
    }
}