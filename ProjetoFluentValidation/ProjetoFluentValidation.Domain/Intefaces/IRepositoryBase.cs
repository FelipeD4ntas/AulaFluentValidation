using ProjetoFluentValidation.Domain.Entidades;

namespace ProjetoFluentValidation.Domain.Intefaces
{
    public interface IRepositoryBase<TEntity> where TEntity : EntidadeBase
    {
        void Adicionar(TEntity entity);
        void Commit();
    }
}
