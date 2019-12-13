using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using split_timer_api.Entities;
using split_timer_api.ViewModel;

namespace Web.ViewModel
{
    public class GetRunViewModel
    {
        public RunDefinitionViewModel RunDefinition { get; set; }
        public Run BestRun { get; set; }
        public long? BestPossibleTime { get; set; }
    }
}
