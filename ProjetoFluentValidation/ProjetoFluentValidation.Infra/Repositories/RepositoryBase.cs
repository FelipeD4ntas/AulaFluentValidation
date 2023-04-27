using Microsoft.EntityFrameworkCore;
using ProjetoFluentValidation.Domain.Entidades;
using ProjetoFluentValidation.Domain.Intefaces;
using ProjetoFluentValidation.Infra.Context;

namespace ProjetoFluentValidation.Infra.Repositories;

public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : EntidadeBase
{
    private readonly AppContextDB _context;
    private readonly DbSet<TEntity> _entitySet;

    public RepositoryBase(AppContextDB context)
    {
        _context = context;
        _entitySet = context.Set<TEntity>();
    }

    public void Adicionar(TEntity entity)
    {
        _entitySet.Add(entity);
    }

    public void Commit()
    {
        _context.SaveChanges();
    }
}
