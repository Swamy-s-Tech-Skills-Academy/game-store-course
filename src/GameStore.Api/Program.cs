using GameStore.Api.Dtos;
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
List<Genre> genres =
[
    new Genre { Id = new Guid("d9890ce7-3f8b-4cb8-8421-e4cd736ce962"), Name = "Fighting" },
    new Genre { Id = new Guid("b510fddf-3ea6-4761-90fb-e38a79d6c73a"), Name = "Kids and Family" },
    new Genre { Id = new Guid("82992021-a9e0-47dd-8bc2-044250363da3"), Name = "Racing" },
    new Genre { Id = new Guid("ddd00345-ac86-4023-854e-4f29d70fbe8d"), Name = "Roleplaying" },
    new Genre { Id = new Guid("09f01785-4435-4958-bc1e-0b78150c464f"), Name = "Sports" },
];


List<Game> games =
[
    new Game
    {
        Id = Guid.NewGuid(),
        Name = "Street Fighter II",
        Genre = genres[0],
        Price = 19.99m,
        ReleaseDate = new DateOnly(1992, 7, 15),
        Description = "A classic fighting game that set the standard for the genre."
    },
    new Game {
        Id = Guid.NewGuid(),
        Name = "Final Fantasy XIV",
        Genre = genres[3],
        Price = 59.99m,
        ReleaseDate = new DateOnly(2010, 9, 30),
        Description = "A massively multiplayer online role-playing game (MMORPG) set in the Final Fantasy universe."
    },
    new Game
    {
        Id = Guid.NewGuid(),
        Name = "FIFA 23",
        Genre = genres[4],
        Price = 69.99m,
        ReleaseDate = new DateOnly(2022, 9, 27),
        Description = "The latest installment in the FIFA series, featuring realistic football simulation."
    }
];

// GET /games
app.MapGet("/games", () => games.Select(game => new GameSummaryDto(
        game.Id,
        game.Name,
        (game.Genre?.Id ?? Guid.Empty).ToString(),
        game.Price,
        game.ReleaseDate)))
    .WithName("GetAllGames")
    .WithTags("Games")
    .Produces<List<GameSummaryDto>>(StatusCodes.Status200OK)
    .Produces(StatusCodes.Status500InternalServerError);

// GET /games/{id}
app.MapGet("/games/{id:guid}", (Guid id) =>
{
    Game? game = games.FirstOrDefault(g => g.Id == id);

    GameDetailsDto? gameDetails = game is not null
        ? new GameDetailsDto(
            game.Id,
            game.Name,
            game.Genre?.Id ?? Guid.Empty,
            game.Price,
            game.ReleaseDate,
            game.Description)
        : null;

    return (game is null) ? Results.NotFound() : Results.Ok(game);
})
    .WithName("GetGameById")
    .WithTags("Games")
    .Produces<Game>(StatusCodes.Status200OK)
    .Produces(StatusCodes.Status404NotFound)
    .Produces(StatusCodes.Status500InternalServerError);

// POST /games
app.MapPost("/games", (CreateGameDto gameDto) =>
{
    var genre = genres.FirstOrDefault(g => g.Id == gameDto.GenreId);
    if (genre is null)
    {
        return Results.BadRequest("Invalid genre ID.");
    }

    var game = new Game
    {
        Id = Guid.NewGuid(),
        Name = gameDto.Name,
        Genre = genre,
        Price = gameDto.Price,
        ReleaseDate = gameDto.ReleaseDate,
        Description = gameDto.Description
    };
    games.Add(game);

    GameDetailsDto? gameDetails = game is not null
        ? new GameDetailsDto(
            game.Id,
            game.Name,
            game.Genre?.Id ?? Guid.Empty,
            game.Price,
            game.ReleaseDate,
            game.Description)
        : null;

    return Results.CreatedAtRoute("GetGameById", new { id = game?.Id }, gameDetails);
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

// GET /genres
app.MapGet("/genres", () => genres.Select(genre => new GenreDto(
        genre.Id,
        genre.Name)))
    .WithName("GetAllGenres")
    .WithTags("Genres")
    .Produces<List<GenreDto>>(StatusCodes.Status200OK)
    .Produces(StatusCodes.Status500InternalServerError);

app.Run();
