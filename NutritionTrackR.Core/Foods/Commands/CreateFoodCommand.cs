﻿using FluentResults;
using MediatR;
using NutritionTrackR.Core.Foods.ValueObjects;
using NutritionTrackR.Core.Shared;

namespace NutritionTrackR.Core.Foods.Commands;

public record CreateFoodCommand(string Name, List<Nutrient> Nutrients) : IRequest<Result>;

public class CreateFoodHandler(INutritionDbContext dbContext) : IRequestHandler<CreateFoodCommand, Result>
{
    public async Task<Result> Handle(CreateFoodCommand command, CancellationToken cancellationToken)
    {
        var foodResult = Food.Create(command.Name, command.Nutrients);

        if (foodResult.IsFailed)
            return Result.Fail(foodResult.Errors);

        var food = foodResult.Value;
        await dbContext.Foods.AddAsync(food, cancellationToken);

        await dbContext.SaveChangesAsync(cancellationToken);
        
        return Result.Ok();
    }
}
