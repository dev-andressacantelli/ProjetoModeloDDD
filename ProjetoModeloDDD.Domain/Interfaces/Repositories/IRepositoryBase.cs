using System.Collections.Generic;


namespace ProjetoModeloDDD.Domain.Interfaces.Repositories
{
    //REPOSITÓRIO BASE É RESPONSÁVEL POR CRUD
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetId(int id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(TEntity obj);
        void Dispose();
        TEntity GetById(int id);
    }
}
