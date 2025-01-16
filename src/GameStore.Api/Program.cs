WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);

// Add services to the container.

WebApplication? app = builder.Build();

// Http Request pipeline Configuration

app.MapGet("/", () => "Hello World!");

app.Run();
