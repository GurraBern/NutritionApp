﻿using MediatR;
using NutritionTrackR.Core.Food.ValueObjects;
using NutritionTrackR.Core.Shared.Abstractions;

namespace NutritionTrackR.Core.Food.Commands;

public record CreateFoodCommand(string Name, List<Nutrient> Nutrients) : IRequest<Result>;

public class CreateFoodCommandHandler(IFoodRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<CreateFoodCommand, Result>
{
    public async Task<Result> Handle(CreateFoodCommand command, CancellationToken cancellationToken)
    {
        var result = Food.Create(command.Name, command.Nutrients);

        if (result.IsSuccess)
            return Result.Failure(result.Error);
        
        await repository.CreateFood(result.Data);
        
        await unitOfWork.SaveAsync();
        
        return Result.Success();
    }
}
