namespace EFSoft.Customers.Api.Configuration;

public sealed class Result<T>
{
    private Result(T value)
    {
        Value = value;
        Error = null;
    }

    private Result(Error error)
    {
        Error = error;
        Value = default;
    }

    public T? Value { get; set; }
    public Error? Error { get; set; }
    public bool IsSuccess => Error == null;

    public static Result<T> Success(T value) => new Result<T>(value);
    public static Result<T> Failure(Error error) => new Result<T>(error);
    public TResult Map<TResult>(Func<T, TResult> onSuccess, Func<Error, TResult> onFailure) => IsSuccess ? onSuccess(Value!) : onSuccess(Value!);
}
