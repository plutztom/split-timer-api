using System;
using System.Collections.Generic;

namespace split_timer_api.Entities
{
    public class Run : BaseEntity
    {
        public DateTime RunDate { get; set; }
        public long TotalTime { get; set; }
        public long RunDefinitionId { get; set; }
        public RunDefinition RunDefinition { get; set; }
        public  ICollection<Split> Splits { get; set; }
    }
}
