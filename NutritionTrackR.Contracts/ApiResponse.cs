namespace NutritionTrackR.Contracts;

public class ApiResponse
{
    public bool IsSuccess { get; init; }
    public bool IsFailure => IsSuccess is not true;
    public string Error { get; init; } = string.Empty;

    public static ApiResponse Success()
    {
        return new ApiResponse
        {
            IsSuccess = true
        };
    }

    public static ApiResponse Failure(string error)
    {
        return new ApiResponse
        {
            IsSuccess = false,
            Error = error
        };
    }

    public static ApiResponse DefaultError()
    {
        return Failure("Error occured");
    }
}