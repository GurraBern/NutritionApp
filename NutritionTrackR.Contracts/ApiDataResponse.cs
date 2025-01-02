namespace NutritionTrackR.Contracts;

public class ApiDataResponse<T>
{
    public bool IsSuccess { get; set; }
    public bool IsFailure => IsSuccess is not true;
    public T? Data { get; set; }
    public string Error { get; set; } = string.Empty;

    public static ApiDataResponse<T> Success(T data)
    {
        return new ApiDataResponse<T>
        {
            IsSuccess = true,
            Data = data
        };
    }
    
    public static ApiDataResponse<T> Success()
    {
        return new ApiDataResponse<T>
        {
            IsSuccess = true
        };
    }

    public static ApiDataResponse<T> Failure(string error)
    {
        return new ApiDataResponse<T>
        {
            IsSuccess = false,
            Data = default,
            Error = error
        };
    }
}