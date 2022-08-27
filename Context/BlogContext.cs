using BlogSemEntity.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogSemEntity.Context
{
    public class BlogContext : DbContext
    {
        public DbSet<Usuario>? Usuarios { get; set; }

        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {
        }
    }
}