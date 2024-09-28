using PersonalHealthAPI.Extensions;
using PersonalHealthAPI.Features.Food;
using PersonalHealthAPI.Features.NutrientTracking;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); //TODO remove use minmal api instead
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// builder.Services.AddFirebaseAuthentication();
builder.Services.AddAuthorization();

// builder.Services.AddSingleton(FirebaseApp.Create(new AppOptions()
// {
//     Credential = GoogleCredential.GetApplicationDefault(),
// }));

// builder.Services.AddSingleton(FirestoreDb.Create("nutritiontracker-f8aba"));

builder.SetupPersistence();

builder.SetupHandlersAndMediatR();

var app = builder.Build();

//Map Endpoints
app.MapCreateFood();
app.MapGetFoods();
app.MapTrackFood();

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