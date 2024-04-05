using animeRanking.Contracts;
using animeRanking.Data;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("AnimeList");
builder.Services.AddSqlite<AnimeContext>(connString);


var app = builder.Build();

app.mapAnimesEndpoints();
app.MigrateDb();

app.Run();
