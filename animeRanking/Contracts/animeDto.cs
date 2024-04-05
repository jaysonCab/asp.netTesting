using System.ComponentModel.DataAnnotations;
using animeRanking.Data;

namespace animeRanking.Contracts;

public record class animesSummaryDto(
  int Id,
  string Name,
  string Genre,
  decimal Ranking,
  string Season
);

public record class createAnimeDto(
  [Required] string Name,
  int GenreId,
  [Required][Range(0, 10)] decimal Ranking,
  [Required][StringLength(15)] string Season
);

public record class updateAnimeDto(
  string Name,
  string Genre,
  decimal Ranking,
  string Season
);

public static class animeEndpoint
{
  const string animeEndpointName = "getAnime";
  private static readonly List<animesSummaryDto> animes = [
  new (
    1,
    "One Piece",
    "Adventure",
    8.72M,
    "Fall 1999"
  ),
  new (
    2,
    "Sakurasou",
    "Romance",
    8.07M,
    "Fall 2012"
  ),
  new (
    3,
    "Kill la Kill",
    "Action",
    8.03M,
    "Fall 2013"
  ),
  new (
    4,
    "Your Name",
    "Drama",
    8.84M,
    "Summer 2016"
  ),
  new (
    5,
    "KonoSuba",
    "Fantasy",
    8.10M,
    "Winter 2016"
  )
  ];

  public static RouteGroupBuilder mapAnimesEndpoints(this WebApplication app)
  {
    var group = app.MapGroup("animes").WithParameterValidation();
        
    //GET anime list
    group.MapGet("/", () => animes);


    //GET anime by ID test grab
    group.MapGet("/{Id}", (int Id, AnimeContext dbContext) => 
      {
        Anime? anime = dbContext.Anime.Find(Id);

        return anime is null ? Results.NotFound() : Results.Ok(anime);
      })
      .WithName(animeEndpointName);


    // POST add new item into list
    group.MapPost("/", (createAnimeDto newAnime, AnimeContext dbContext) =>
    {
      

      Anime anime = new()
      {
        Name = newAnime.Name,
        Genre = dbContext.Genres.Find(newAnime.GenreId),
        GenreID = newAnime.GenreId,
        Ranking = newAnime.Ranking,
        Season = newAnime.Season
      };

      dbContext.Anime.Add(anime);
      dbContext.SaveChanges();

      animesSummaryDto animeDto = new(
        anime.Id,
        anime.Name,
        anime.Genre!.Name,
        anime.Ranking,
        anime.Season
      );

      GameDetails animeGamesDto = new(
        anime.Id,
        anime.Name,
        anime.GenreID,
        anime.Ranking,
        anime.Season
      );

      return Results.CreatedAtRoute(animeEndpointName, new {id = anime.Id}, animeDto);
      });

    //PUT update anime in list |replace ID with whatever gonna be sent|
    group.MapPut("/{Id}", (int Id, updateAnimeDto updatedAnime) => {
      var index = animes.FindIndex(game => game.Id == Id);

      if(index == -1)
      {
        return Results.NotFound();
      }

      animes[index] = new animesSummaryDto(
        Id,
        updatedAnime.Name,
        updatedAnime.Genre,
        updatedAnime.Ranking,
        updatedAnime.Season
      );

      return Results.NoContent();
    });

    //Deletes ID
    group.MapDelete("/{Id}", (int Id) =>
    {
      animes.RemoveAll(anime => anime.Id == Id);

      return Results.NoContent();
    });

    return group;
  }


}