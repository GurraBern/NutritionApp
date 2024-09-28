namespace NutritionTrackR.Core.Shared.Abstractions;

public class Error
{
	public Error(string message, string code = "")
	{
		Message = message;
		Code = code;
	}

	public string Code { get; }
	public string Message { get; }

	public static Error None => new(string.Empty);
	public static implicit operator Error(string message) => new(message);

	public static implicit operator string(Error error) => error.Message;
}