namespace SearchApiService.Repository
{
    public interface IResultsRepository<TEntity, in TId>
        where TEntity : class
    {
        TEntity GetById(TId id);
    }
}