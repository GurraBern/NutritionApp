using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NutritionTrackR.Core.Foods.ValueObjects;
using NutritionTrackR.Core.Shared;

namespace NutritionTrackR.Core.Nutrition.Target.Commands;

public record CreateNutritionTargetCommand(DateTime StartDate, List<Nutrient> NutrientGoals) : IRequest<Result>;

public class CreateNutritionTarget(INutritionDbContext dbContext) : IRequestHandler<CreateNutritionTargetCommand, Result>
{
	public async Task<Result> Handle(CreateNutritionTargetCommand command, CancellationToken cancellationToken)
	{
		var nutrientGoalsToAdd = command.NutrientGoals;
		
		var nutritionTarget = await dbContext.NutritionTargets.SingleOrDefaultAsync(x => x.ActivationDate == command.StartDate, cancellationToken);
		if (nutritionTarget is null)
		{
			nutritionTarget = new NutritionTarget(command.StartDate, nutrientGoalsToAdd);
			dbContext.NutritionTargets.Add(nutritionTarget);
		}
		else
		{
			nutritionTarget.AddOrUpdateNutrientTargets(nutrientGoalsToAdd);
		}

		await dbContext.SaveChangesAsync(cancellationToken);
		
		return Result.Ok();
	}
}
