using FluentValidation.Results;

namespace Application.Exceptions;

public class CommandValidationException<TRequest>(
    List<ValidationFailure> validationFailures
) : CommandValidationException(
    validationFailures,
    $"Validación de {typeof(TRequest)} falló por las siguientes razones: {Reasons(validationFailures)}"
);

public class CommandValidationException : Exception
{
    protected CommandValidationException(List<ValidationFailure> validationFailures, string message = "") : base(
        string.IsNullOrEmpty(message)
            ? $"Validación falló debido a las siguientes razones: {Reasons(validationFailures)}"
            : message)
    {
        Errors = validationFailures.Select(r => r.ErrorMessage).ToList();
    }

    public List<string> Errors { get; }

    protected static string Reasons(IEnumerable<ValidationFailure> validationFailures)
    {
        return string.Join(", ", validationFailures.Select(x => $"{x.PropertyName}: {x.ErrorMessage}"));
    }
}
