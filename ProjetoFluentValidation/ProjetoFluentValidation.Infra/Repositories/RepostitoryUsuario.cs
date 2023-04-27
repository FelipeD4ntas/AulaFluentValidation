using ProjetoFluentValidation.Domain.Entidades;
using ProjetoFluentValidation.Domain.Intefaces;
using ProjetoFluentValidation.Infra.Context;

namespace ProjetoFluentValidation.Infra.Repositories;

public class RepostitoryUsuario : RepositoryBase<Usuario>, IRepositoryUsuario
{
    public RepostitoryUsuario(AppContextDB context) : base(context)
    {
    }
}
