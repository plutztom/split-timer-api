using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using split_timer_api.Entities;

namespace split_timer_api
{
    public interface IStDbContext
    {
        DbSet<Run> Runs { get; set; }
        DbSet<RunDefinition> RunDefinitions { get; set; }
        DbSet<Split> Splits { get; set; }
        DbSet<SplitDefinition> SplitDefinitions { get; set; }
        DbSet<User> Users { get; set; }

        Task<int> SaveChangesAsync();
    }
}
