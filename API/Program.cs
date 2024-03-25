using API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddIndentityServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200"));

// add the authorization middleware before the map controllers middleware

app.UseAuthentication();    // asking: do you have an authorised token? / valid ID?

app.UseAuthorization();      // asking: do you have the right to access this resource? / enough age for the nightclub?

app.MapControllers();

app.Run();
