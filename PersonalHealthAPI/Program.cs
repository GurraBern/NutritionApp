using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NutritionTrackR.Core.Food;
using NutritionTrackR.Core.Food.Commands;
using NutritionTrackR.Core.Shared;
using NutritionTrackR.Core.Shared.Abstractions;
using NutritionTrackR.Persistence;
using NutritionTrackR.Persistence.Repositories;
using PersonalHealthAPI.Features.Food;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
// builder.Services.AddFirebaseAuthentication();
builder.Services.AddAuthorization();

// builder.Services.AddSingleton(FirebaseApp.Create(new AppOptions()
// {
//     Credential = GoogleCredential.GetApplicationDefault(),
// }));

// builder.Services.AddSingleton(FirestoreDb.Create("nutritiontracker-f8aba"));

//Settings
builder.Services
    .AddOptions<DatabaseSettings>()
    .Bind(builder.Configuration.GetSection(nameof(DatabaseSettings)))
    .ValidateDataAnnotations();

builder.Services.AddDbContext<NutritionDbContext>((serviceProvider, options) =>
{
    var settings = serviceProvider.GetRequiredService<IOptions<DatabaseSettings>>();
    options.UseMongoDB(settings.Value.ConnectionString, "NutritionTrackR");
});


//Repositories
builder.Services.AddScoped<IUnitOfWork, EfUnitOfWork>();
builder.Services.AddScoped<IFoodRepository, FoodRepository>();

//MediatR Handlers

builder.Services.AddMediatR(cfg =>
    {
        cfg.RegisterServicesFromAssembly(typeof(MediatRMarker).Assembly);
    })
    .AddScoped<IRequestHandler<CreateFoodCommand, Result>, CreateFoodCommandHandler>();


var app = builder.Build();

//Map Endpoints
app.MapCreateFood();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();