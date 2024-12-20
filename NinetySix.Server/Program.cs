using NinetySix.Server.Persistence;
using NinetySix.Server.Persistence.Seed;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddPersistenceService(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
app.InitialiseDatabaseAsync();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();