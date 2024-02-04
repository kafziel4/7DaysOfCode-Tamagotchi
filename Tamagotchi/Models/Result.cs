namespace Tamagotchi.Models;

public class Result<TValue>
{
    public bool IsSuccess { get; }
    public TValue? Value { get; }
    public string? Error { get; }

    private Result(TValue? value, bool isSuccess, string? error)
    {
        Value = value;
        IsSuccess = isSuccess;
        Error = error;
    }

    public static implicit operator Result<TValue>(TValue value) => new(value, true, default);
    public static implicit operator Result<TValue>(string error) => new(default, false, error.ToUpper());
}
