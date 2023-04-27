namespace ProjetoFluentValidation.Domain.Commands.UsuarioCommands.AdicionarUsuario;
public class AdicionarUsuarioResponse
{
    public Guid Id { get; private set; }
    public string Mensagem { get; private set; }
   

    public AdicionarUsuarioResponse(Guid id, string mensagem)
    {
        Id = id;
        Mensagem = mensagem;
    }
}
