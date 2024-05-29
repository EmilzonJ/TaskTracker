namespace Application.Exceptions;

public class ExceptionResponse
{
    public string Title { get; set; }
    public int StatusCode { get; set; }
    public IEnumerable<string> Errors { get; set; }
}
