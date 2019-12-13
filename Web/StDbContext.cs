using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using split_timer_api.Entities;

namespace split_timer_api
{
    public class StDbContext : DbContext, IStDbContext
    {
        public DbSet<Run> Runs { get; set; }
        public DbSet<RunDefinition> RunDefinitions { get; set; }
        public DbSet<Split> Splits { get; set; }
        public DbSet<SplitDefinition> SplitDefinitions { get; set; }
        public DbSet<User> Users { get; set; }

        public StDbContext(DbContextOptions options) : base(options) { }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync(CancellationToken.None);
        }
    }
}
