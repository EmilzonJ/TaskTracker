namespace Application.Exceptions;

public class BadRequestException(string errorMessage) : Exception
{
    public IEnumerable<string> Errors { get; } = new[] { errorMessage };
}
