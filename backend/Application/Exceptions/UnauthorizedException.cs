namespace Application.Exceptions;

public class UnauthorizedException(string errorMessage) : Exception
{
    public IEnumerable<string> Errors { get; } = new[] { errorMessage };
}
