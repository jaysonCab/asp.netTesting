using animeRanking.Entities;

namespace animeRanking;

public class Anime
{
  public int Id { get; set; }
  public required string Name { get; set; }
  public int GenreID { get; set; }
  public Genre? Genre { get; set; }

  public decimal Ranking { get; set; }

  public string? Season { get; set; }

}
