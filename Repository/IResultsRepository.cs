namespace SearchApiService.Repository
{
    public interface IResultsRepository<out TEntity, in TId>
        where TEntity : class
    {
        TEntity GetById(TId id);
    }
}