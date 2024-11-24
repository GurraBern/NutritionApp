using MediatR;
using NutritionTrackR.Core.Foods.ValueObjects;

namespace NutritionTrackR.Core.Nutrition.Target.Commands;

public class CreateNutritionTargetCommand : IRequest
{
	public DateOnly StartDate { get; set; }
	public List<Nutrient> NutrientGoals { get; set; } = [];
}

public class CreateNutritionTarget(INutrientTargetRepository repository) : IRequestHandler<CreateNutritionTargetCommand>
{
	public Task Handle(CreateNutritionTargetCommand request, CancellationToken cancellationToken)
	{
		//TODO kolla om det redan finns en dag? Isåfall ersätt dagen med ny data, annars skapa ny bara
		
		throw new NotImplementedException();
	}
}
