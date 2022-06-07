#nullable disable
using Microsoft.EntityFrameworkCore;

namespace ThanksCardAPI.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<ThanksCard> ThanksCards { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Good> Goods { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
