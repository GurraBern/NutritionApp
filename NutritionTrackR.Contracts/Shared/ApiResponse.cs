namespace NutritionTrackR.Contracts.Shared;

public class ApiResponse<T> : ApiResult
{
	public T? Data { get; }

	public ApiResponse(bool isSuccess, Error error, T? data) : base(isSuccess, error)
	{
		Data = data;
	}
}

public class ApiResult
{
	public ApiResult(bool isSuccess, Error error)
	{
		IsSuccess = isSuccess;
		Error = error;
	}

	public bool IsSuccess { get; }
	public Error Error { get; }

	public static ApiResult Success() => new(true, Error.None);

	public static ApiResult Failure(Error error) => new(false, error);

	public static ApiResponse<T> Success<T>(T data) => new(true, Error.None, data);

	public static ApiResponse<T> Failure<T>(Error error) => new(false, error, default);
}