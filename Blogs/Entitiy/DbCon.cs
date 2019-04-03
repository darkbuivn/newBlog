using System.Data.Entity;

namespace Blog.Entities
{
    public class DbCon : DbContext
    {
        public DbCon()
            : base("DefaultConnection")
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Block> Blocks { get; set; }
    }
}