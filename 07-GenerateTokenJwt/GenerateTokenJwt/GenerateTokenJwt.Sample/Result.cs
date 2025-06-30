namespace GenerateTokenJwt.Sample;

public class Result
{
    public bool IsSuccess { get; }
    public string Error { get; }

    private Result(bool isSuccess, string? error = null)
    {
        IsSuccess = isSuccess;
        Error = error ?? string.Empty;
    }

    public static Result Success() => new(isSuccess: true);

    public static Result Failure(string error) => new(isSuccess: false, error);
}