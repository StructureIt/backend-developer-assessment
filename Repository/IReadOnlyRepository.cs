
using System.Linq;
using SearchApiService.Models;

namespace SearchApiService.Repository
{
    public interface IReadOnlyRepository<out TEntity, in TId> 
        where TEntity: class 
    {
        IQueryable<TEntity> GetAll();

        TEntity GetById(TId id);
        
        IQueryable<TEntity> SearchByName(SearchRequest request);
    }
}