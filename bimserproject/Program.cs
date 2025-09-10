using BimserProject.Business.Services;
using BimserProject.Core.Core.Interfaces;
using BimserProject.Core.Core.Interfaces.Repositories;
using BimserProject.Core.Core.Interfaces.Services;
using BimserProject.Data.Data.contexts;
using BimserProject.Data.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.WriteIndented = true;
    });


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<IFilmRepository, FilmRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IWatchHistoryRepository, WatchHistoryRepository>();

// Services
builder.Services.AddScoped<IFilmService, FilmService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IWatchHistoryService, WatchedFilmService>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();