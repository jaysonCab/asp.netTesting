namespace animeRanking.Contracts;
public record class GameDetails(
  int Id,
  string Name,
  int GenreId,
  decimal Ranking,
  string Season
);