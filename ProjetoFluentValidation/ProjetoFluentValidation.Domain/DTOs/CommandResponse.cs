using FluentValidation.Results;
using MediatR;

namespace ProjetoFluentValidation.Domain.DTOs;

public class CommandResponse
{
    public bool Success { get; }
    public object Data { get; }
    public List<Dictionary<string, string>> Notificacoes { get; } = new List<Dictionary<string, string>>();


    public CommandResponse(object data, ValidationResult result)
    {
        Success = true;
        Data = result.IsValid ? data : null;
    }

    public CommandResponse(ValidationResult result)
    {
        foreach (var erro in result.Errors)
        {
            var notificacao = new Dictionary<string, string>();
            notificacao.Add(erro.PropertyName, erro.ErrorMessage);

            Notificacoes.Add(notificacao);

        }
    }
}
