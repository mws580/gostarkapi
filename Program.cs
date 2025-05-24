var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Add support for controllers
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// Map controller endpoints
app.MapControllers();
app.UseCors();
var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.MapGet("/joke", () =>
{
    var jokes = new[]
    {
        "Why don't scientists trust atoms? Because they make up everything!",
        "Why did the scarecrow win an award? Because he was outstanding in his field!",
        "Why don't programmers like nature? It has too many bugs.",
        "Why do Java developers wear glasses? Because they don't see sharp.",
        "How do you comfort a JavaScript bug? You console it."
    };
    var joke = jokes[Random.Shared.Next(jokes.Length)];
    return Results.Ok(new { joke });
})
.WithName("GetJoke");

app.MapGet("/youtubevideo", () =>
{
    var videos = new[]
    {
        new {
            Id = "dQw4w9WgXcQ",
            Description = "Rick Astley - Never Gonna Give You Up (Official Music Video)",
            Thumbnail = "https://img.youtube.com/vi/dQw4w9WgXcQ/hqdefault.jpg",
            Link = "https://www.youtube.com/watch?v=dQw4w9WgXcQ",
            Playlist = "https://www.youtube.com/playlist?list=PLFgquLnL59alCl_2TQvOiD5Vgm1hCaGSI"
        },
        new {
            Id = "9bZkp7q19f0",
            Description = "PSY - GANGNAM STYLE(강남스타일) M/V",
            Thumbnail = "https://img.youtube.com/vi/9bZkp7q19f0/hqdefault.jpg",
            Link = "https://www.youtube.com/watch?v=9bZkp7q19f0",
            Playlist = "https://www.youtube.com/playlist?list=PLDcnymzs18LVXfO_x0Ei0R24qDbVtyy66"
        },
        new {
            Id = "3JZ_D3ELwOQ",
            Description = "Mark Ronson - Uptown Funk (Official Video) ft. Bruno Mars",
            Thumbnail = "https://img.youtube.com/vi/3JZ_D3ELwOQ/hqdefault.jpg",
            Link = "https://www.youtube.com/watch?v=3JZ_D3ELwOQ",
            Playlist = "https://www.youtube.com/playlist?list=PLrEnWoR732-BHrPp_Pm8_VleD68f9s14-"
        }
    };
    var video = videos[Random.Shared.Next(videos.Length)];
    return Results.Ok(video);
})
.WithName("GetYouTubeVideo");

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
