using MediatR;
using NutritionTrackR.Core.Foods.ValueObjects;
using NutritionTrackR.Core.Shared.Abstractions;

namespace NutritionTrackR.Core.Nutrition.Target.Commands;

public class CreateNutritionTargetCommand : IRequest<Result>
{
	public DateTime StartDate { get; set; }
	public List<Nutrient> NutrientGoals { get; set; } = [];
}

public class CreateNutritionTargetHandler(INutritionTargetRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<CreateNutritionTargetCommand, Result>
{
	public async Task<Result> Handle(CreateNutritionTargetCommand command, CancellationToken cancellationToken)
	{
		var nutritionTarget = await repository.GetNutritionTarget(command.StartDate) ?? new NutritionTarget
		{
			ActivationDate = command.StartDate,
			Nutrients = command.NutrientGoals
		};
		
		await repository.Add(nutritionTarget);

		await unitOfWork.SaveAsync();
		
		return Result.Success();
	}
}
