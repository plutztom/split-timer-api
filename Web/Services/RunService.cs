using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using split_timer_api;
using split_timer_api.Entities;
using split_timer_api.ViewModel;
using Web.ViewModel;

namespace Web.Services
{
    public class RunService : IRunService
    {
        private readonly IStDbContext _dbContext;

        public RunService(IStDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SaveRun(Run run)
        {
            _dbContext.Runs.Add(run);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<GetRunViewModel> GetRunDefinition(long runDefinitionId)
        {
            var runDefinition = await _dbContext.RunDefinitions.Where(d => d.Id == runDefinitionId).Select(d =>
                new RunDefinitionViewModel
                {
                    Id = d.Id,
                    Game = d.Game,
                    Category = d.Category,
                    Splits = d.SplitDefinitions.Select(s => new SplitDefinitionViewModel
                    {
                        Id = s.Id,
                        Name = s.Name,
                        Order = s.Order,
                        BestTime = _dbContext.Splits.Where(best => best.SplitDefinitionId == s.Id)
                            .Select(max => max.Time).Min()
                    }).ToList()
                }).FirstOrDefaultAsync();

            var bestRun = await _dbContext.Runs.Where(r => r.RunDefinitionId == runDefinitionId)
                .OrderBy(r => r.TotalTime).FirstOrDefaultAsync();

            var bestPossibleTime = await _dbContext.SplitDefinitions
                .Where(sd => sd.RunDefinitionId == runDefinitionId)
                .Select(sd => sd.Splits.Select(s => s.Time).Min()).SumAsync();

            return new GetRunViewModel
            {
                BestPossibleTime = bestPossibleTime,
                BestRun = bestRun,
                RunDefinition = runDefinition
            };
        } 
    }
}
