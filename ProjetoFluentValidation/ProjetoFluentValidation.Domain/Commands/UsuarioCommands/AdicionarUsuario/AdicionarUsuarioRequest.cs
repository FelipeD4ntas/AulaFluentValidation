using MediatR;
using ProjetoFluentValidation.Domain.DTOs;

namespace ProjetoFluentValidation.Domain.Commands.UsuarioCommands.AdicionarUsuario;

public class AdicionarUsuarioRequest : IRequest<CommandResponse>
{
    public string Nome { get; private set; }
    public string Email { get; private set; }
    public int Idade { get; private set; }

    public AdicionarUsuarioRequest(string nome, string email, int idade)
    {
        Nome = nome;
        Email = email;
        Idade = idade;
    }
}
