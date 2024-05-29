namespace Application.Exceptions;

public class UnprocessableEntityException(string error) : Exception
{
    public IEnumerable<string> Errors { get; } = new[] { error };
}
