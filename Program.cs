using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Register controllers
builder.Services.AddControllers();

var app = builder.Build();

// Enable attribute routing for controllers
app.MapControllers();

app.Run();

