using MediatR;
using NutritionTrackR.Core.Foods.ValueObjects;
using NutritionTrackR.Core.Shared.Abstractions;

namespace NutritionTrackR.Core.Nutrition.Target.Commands;

public record CreateNutritionTargetCommand(DateTime StartDate, List<Nutrient> NutrientGoals) : IRequest<Result>;

public class CreateNutritionTarget(INutritionTargetRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<CreateNutritionTargetCommand, Result>
{
	public async Task<Result> Handle(CreateNutritionTargetCommand command, CancellationToken cancellationToken)
	{
		var nutritionTarget = await repository.GetNutritionTarget(command.StartDate);
		if (nutritionTarget is null)
		{
			nutritionTarget = new NutritionTarget(command.StartDate, command.NutrientGoals);
			await repository.Add(nutritionTarget);
		}
		else
		{
			nutritionTarget.ReplaceNutrients(command.NutrientGoals);
		}
		
		await unitOfWork.SaveAsync();
		
		return Result.Success();
	}
}
