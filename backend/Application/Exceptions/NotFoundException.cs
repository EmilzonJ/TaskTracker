namespace Application.Exceptions;

public class NotFoundException(string errorMessage) : Exception
{
    public IEnumerable<string> Errors { get; } = new[] { errorMessage };
}
