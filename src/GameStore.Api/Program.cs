using GameStore.Api.Models;

WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);

// Add services to the container.

WebApplication? app = builder.Build();

// Http Request pipeline Configuration


// Endpoints
app.MapGet("/", () => new
{
    Message = "Welcome to the Games API",
    RequestId = Guid.NewGuid(),
    DateTime = DateTime.UtcNow
});


// Data Store - Not a Thread-safe implementation, for demonstration purposes only.
List<Game> games =
[
    new Game {
        Id = Guid.NewGuid(),
        Name = "Street Fighter II",
        Genre = "Fighting",
        Price = 19.99m,
        ReleaseDate = new DateOnly(1992, 7, 15)
    },
    new Game {
        Id = Guid.NewGuid(),
        Name = "Final Fantasy XIV",
        Genre = "Roleplaying",
        Price = 59.99m,
        ReleaseDate = new DateOnly(2010, 9, 30) },
    new Game {
        Id = Guid.NewGuid(),
        Name = "FIFA 23",
        Genre = "Sports",
        Price = 69.99m,
        ReleaseDate = new DateOnly(2022, 9, 27) }
];

// GET /games
app.MapGet("/games", () => games)
    .WithName("GetAllGames")
    .WithTags("Games")
    .Produces<List<Game>>(StatusCodes.Status200OK)
    .Produces(StatusCodes.Status500InternalServerError);

// GET /games/{id}
app.MapGet("/games/{id:guid}", (Guid id) =>
{
    Game? game = games.FirstOrDefault(g => g.Id == id);

    return (game is null) ? Results.NotFound() : Results.Ok(game);
})
    .WithName("GetGameById")
    .WithTags("Games")
    .Produces<Game>(StatusCodes.Status200OK)
    .Produces(StatusCodes.Status404NotFound)
    .Produces(StatusCodes.Status500InternalServerError);

// POST /games
app.MapPost("/games", (Game game) =>
{
    game.Id = Guid.NewGuid();
    games.Add(game);

    return Results.CreatedAtRoute("GetGameById", new { id = game.Id }, game);
})
    .WithName("CreateGame")
    .WithTags("Games")
    .WithParameterValidation()
    .Produces<Game>(StatusCodes.Status201Created)
    .Produces(StatusCodes.Status400BadRequest)
    .Produces(StatusCodes.Status500InternalServerError);

// PUT /games/{id}
app.MapPut("/games/{id:guid}", (Guid id, Game updatedGame) =>
{
    Game? existingGame = games.FirstOrDefault(g => g.Id == id);

    if (existingGame is null)
    {
        return Results.NotFound();
    }

    existingGame.Name = updatedGame.Name;
    existingGame.Genre = updatedGame.Genre;
    existingGame.Price = updatedGame.Price;
    existingGame.ReleaseDate = updatedGame.ReleaseDate;

    return Results.NoContent();
})
    .WithName("UpdateGame")
    .WithTags("Games")
    .WithParameterValidation()
    .Produces<Game>(StatusCodes.Status200OK)
    .Produces(StatusCodes.Status404NotFound)
    .Produces(StatusCodes.Status400BadRequest)
    .Produces(StatusCodes.Status500InternalServerError);

// DELETE /games/{id}
app.MapDelete("/games/{id:guid}", (Guid id) =>
{
    Game? existingGame = games.FirstOrDefault(g => g.Id == id);

    if (existingGame is null)
    {
        return Results.NotFound();
    }

    games.Remove(existingGame);
    return Results.NoContent();
})
    .WithName("DeleteGame")
    .WithTags("Games")
    .Produces(StatusCodes.Status204NoContent)
    .Produces(StatusCodes.Status404NotFound)
    .Produces(StatusCodes.Status500InternalServerError);

app.Run();
