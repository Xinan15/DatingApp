using API.Extensions;
using API.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddIndentityServices(builder.Configuration);

var app = builder.Build();      // this is the middleware pipeline

if(builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// Configure the HTTP request pipeline.
app.UseMiddleware<ExceptionMiddleware>();

app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200"));

// add the authorization middleware before the map controllers middleware

app.UseAuthentication();    // asking: do you have an authorised token? / valid ID?

app.UseAuthorization();     // asking: do you have the right to access this resource? / are you enough age to enter the nightclub?

app.MapControllers();

app.Run();
