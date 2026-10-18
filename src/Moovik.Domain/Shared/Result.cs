namespace Moovik.Domain.Shared;

public class Result
{
    public bool IsSuccess { get; private set; }
    public Error? Error { get; private set; }
    public string? Messsage { get; private set; }

    protected Result(bool isSuccess, Error? error = null, string? message = null)
    {
        IsSuccess = isSuccess;
        Error = error;
        Messsage = message;
    }

    public static Result Success(string? message = null) => new(true, null, message);
    public static Result Failure(Error error, string? message = null) => new(false, error, message);
}

public class Result<T> : Result
{
    public T? Data { get; private set; }

    private Result(bool isSuccess, T? data = default, Error? error = null, string? message = null)
        : base(isSuccess, error, message)
    {
        Data = data;
    }

    public static Result<T> Success(T? data = default, string? message = null) => new(true, data, null, message);
    public static new Result<T> Failure(Error error, string? message = null) => new(true, default, error, message);
}
