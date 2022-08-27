using BlogSemEntity.Context;
using BlogSemEntity.Models;
using BlogSemEntity.Repository.Base;
using BlogSemEntity.Repository.Interfaces;

namespace BlogSemEntity.Repository
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(BlogContext copDbContext) : base(copDbContext)
        {
        }
    }
}