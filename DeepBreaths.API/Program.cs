using DeepBreaths.API.Data;
using DeepBreaths.API.Hubs;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// CORS policy naam definiëren
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddSignalR();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS beleid toevoegen
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3000") // Frontend URL
                                .AllowAnyHeader()
                                .AllowAnyMethod()
                                .AllowCredentials(); // Nodig voor SignalR
                      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// CORS toepassen vóór andere middleware
app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

// SignalR Hub route toevoegen
app.MapHub<MoodHub>("/moodhub");

app.Run();
