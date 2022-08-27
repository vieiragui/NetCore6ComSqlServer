namespace BlogSemEntity.Repository.Interfaces
{
    public interface IBaseRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> Select();
        Task<TEntity> SelectPerId(int id);
        Task Update(TEntity modelo);
        Task Remove(TEntity modelo);
        Task Insert(TEntity modelo);
    }
}