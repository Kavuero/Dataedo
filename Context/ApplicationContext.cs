using Microsoft.EntityFrameworkCore;

namespace Dataedo_Zadanie.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        { 

        }

        public DbSet<User> Users { get; set; }
    }
}
