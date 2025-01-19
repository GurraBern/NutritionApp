using NutritionTrackR.Api.Extensions;
using NutritionTrackR.Api.Features.BodyMeasurement;
using NutritionTrackR.Api.Features.Food;
using NutritionTrackR.Api.Features.NutrientTracking;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthorization();

builder.SetupPersistence();

builder.SetupHandlersAndMediatR();

var app = builder.Build();

//Map Endpoints
app.MapCreateFood();
app.MapGetFoods();
app.MapTrackFood();
app.MapGetLoggedFood();
app.MapSetNutritionTarget();
app.MapGetNutritionTarget();
app.MapUpdateLoggedFood();
app.MapDeleteLoggedFood();
app.MapTrackBodyWeight();
app.MapGetBodyWeight();

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








