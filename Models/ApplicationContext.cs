using Microsoft.EntityFrameworkCore;
using ThanksCardAPI.Models;
namespace ThanksCardAPI.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Department> Departments { get; set; } = null!;
        public DbSet<ThanksCard> ThanksCards { get; set; } = null!;
        public DbSet<ThanksCardAPI.Models.Tag> Tag { get; set; } = null!;
    }
}
