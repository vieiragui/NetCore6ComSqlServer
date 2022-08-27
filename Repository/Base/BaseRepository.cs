using BlogSemEntity.Context;
using BlogSemEntity.Models;
using BlogSemEntity.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BlogSemEntity.Repository.Base
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseModel
    {
        public readonly DbSet<TEntity> _DbSet;
        public readonly BlogContext _blogContext;

        public BaseRepository(BlogContext copDbContext)
        {
            _DbSet = copDbContext.Set<TEntity>();
            _blogContext = copDbContext;
        }

        public async Task Insert(TEntity modelo)
        {
            await _DbSet.AddAsync(modelo);
            await _blogContext.SaveChangesAsync();
        }

        public async Task Remove(TEntity modelo)
        {
            _DbSet.Remove(modelo);
            await _blogContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> Select() =>
            await _DbSet.ToListAsync();   
        
        public async Task<TEntity> SelectPerId(int id) =>
            await _DbSet.FindAsync(id);
        

        public async Task Update(TEntity modelo)
        {
            _DbSet.Update(modelo);
            await _blogContext.SaveChangesAsync();
        }
    }
}