using MediatR;
using Microsoft.AspNetCore.Http;
using ProjetoFluentValidation.Domain.DTOs;
using ProjetoFluentValidation.Domain.Entidades;
using ProjetoFluentValidation.Domain.Entidades.Validations;
using ProjetoFluentValidation.Domain.Intefaces;

namespace ProjetoFluentValidation.Domain.Commands.UsuarioCommands.AdicionarUsuario;

public class AdicionarUsuarioHandler : IRequestHandler<AdicionarUsuarioRequest, CommandResponse>
{
    private readonly IRepositoryUsuario _repositoryUsuario;

    public AdicionarUsuarioHandler(IRepositoryUsuario repositoryUsuario)
    {
        _repositoryUsuario = repositoryUsuario;
    }

    public Task<CommandResponse> Handle(AdicionarUsuarioRequest request, CancellationToken cancellationToken)
    {
        var usuario = new Usuario(request.Nome, request.Email, request.Idade);
        var validator = new CriarUsuarioValidator();
        var results = validator.Validate(usuario);

        if (!results.IsValid)
        {
            return Task.FromResult(new CommandResponse(results));
        }

        _repositoryUsuario.Adicionar(usuario);
        _repositoryUsuario.Commit();

        var response = new AdicionarUsuarioResponse(usuario.Id, "Usuario adicionado com sucesso!");

        return Task.FromResult(new CommandResponse(response, results));
    }
}
