using FluentResults;
using MediatR;
using NutritionTrackR.Core.Food.ValueObjects;
using NutritionTrackR.Core.Shared.Abstractions;

namespace NutritionTrackR.Core.Food.Commands;

public record CreateFoodCommand(string Name, IList<Nutrient> Nutrients) : IRequest<Result>;

public class CreateFoodCommandHandler(IFoodRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<CreateFoodCommand, Result>
{
    public async Task<Result> Handle(CreateFoodCommand command, CancellationToken cancellationToken)
    {
        await repository.CreateFood(new Food(command.Name, command.Nutrients));
        
        await unitOfWork.Save();
        
        return Result.Ok();
    }
}
