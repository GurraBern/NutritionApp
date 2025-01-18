using MediatR;
using Microsoft.EntityFrameworkCore;
using NutritionTrackR.Core.Foods.ValueObjects;
using NutritionTrackR.Core.Shared;
using NutritionTrackR.Core.Shared.Abstractions;

namespace NutritionTrackR.Core.Nutrition.Target.Commands;

public record CreateNutritionTargetCommand(DateTime StartDate, List<Nutrient> NutrientGoals) : IRequest<Result>;

public class CreateNutritionTarget(INutritionDbContext dbContext) : IRequestHandler<CreateNutritionTargetCommand, Result>
{
	public async Task<Result> Handle(CreateNutritionTargetCommand command, CancellationToken cancellationToken)
	{
		var nutritionTarget = await dbContext.NutritionTargets
            .SingleOrDefaultAsync(x => x.ActivationDate == command.StartDate, cancellationToken);
		
		if (nutritionTarget is null)
		{
			nutritionTarget = new NutritionTarget(command.StartDate, command.NutrientGoals);
			dbContext.NutritionTargets.Add(nutritionTarget);
		}
		else
		{
			nutritionTarget.ReplaceNutrients(command.NutrientGoals);
		}

		await dbContext.SaveChangesAsync(cancellationToken);
		
		return Result.Success();
	}
}
