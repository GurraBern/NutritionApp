namespace NutritionTrackR.Core.Shared.Abstractions;

public class Result<T>(bool isSuccess, Error error, T data) : Result(isSuccess, error)
{
	public T Data { get; } = data;
}

public class Result(bool isSuccess, Error error)
{
	public bool IsSuccess { get; } = isSuccess;
	
	public bool IsFailure => !IsSuccess;
	
	public Error Error { get; } = error;

	public static Result Success() => new(true, Error.None);

	public static Result Failure(Error error) => new(false, error);

	public static Result<T> Success<T>(T data) => new(true, Error.None, data);

	public static Result<T> Failure<T>(Error error) => new(false, error, default!);
}
