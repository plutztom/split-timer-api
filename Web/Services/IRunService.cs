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
    public interface IRunService
    {

        Task SaveRun(Run run);

        Task<GetRunViewModel> GetRunDefinition(long runDefinitionId);
    }
}
