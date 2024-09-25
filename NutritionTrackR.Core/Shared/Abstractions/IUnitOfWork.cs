namespace NutritionTrackR.Core.Shared.Abstractions;

public interface IUnitOfWork
{
    Task<int> SaveAsync();
}