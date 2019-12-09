using MongoDB.Bson;

using System.Collections.Generic;

namespace APIDelSistemas.Entities.Repository.Base
{
    public interface IRepository<TEntity> where TEntity : class
    {
        bool Add(TEntity item);

        bool Modify(ObjectId key, TEntity item);

        bool Remove(ObjectId key);

        IEnumerable <TEntity> GetById(ObjectId key);

        IEnumerable<TEntity> GetAll();

        //IEnumerable GetFiltered(Expression<Func<TEntity, bool>> filter);
    }
}
