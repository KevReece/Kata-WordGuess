using ScoresApi;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();
app.UseHttpsRedirection();
app.RegisterRoutes(new ScoresRepository());
app.Run();
