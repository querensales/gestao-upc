using FluentValidation.Results;

namespace AppService.Extension;

public class CustomValidationException : Exception
{
    public List<string> Erros { get; }
    public CustomValidationException(List<ValidationFailure>? errors):base("Ocorreram erros de validação.")
    {
        Erros = errors.Select(e => $"{e.ErrorCode} - {e.ErrorMessage}").ToList();
    }

    public CustomValidationException(List<string> erros) : base("Ocorreram erros de validação.")
    {
        Erros = erros ?? new List<string>(); // Inicializa a lista para evitar NullReferenceException
    }

    public CustomValidationException(string mensagem, List<string> erros) : base(mensagem)
    {
        Erros = erros ?? new List<string>();
    }

    public CustomValidationException(string mensagem, Exception innerException, List<string> erros) : base(mensagem, innerException)
    {
        Erros = erros ?? new List<string>();
    }
}