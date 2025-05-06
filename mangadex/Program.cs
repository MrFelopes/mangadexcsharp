using mangadex.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpClient();
builder.Services.AddHttpClient<MangaService>();
builder.Services.AddScoped<MangaService>();

var app = builder.Build();


app.UseAuthorization();

app.MapControllers();

app.Run();
