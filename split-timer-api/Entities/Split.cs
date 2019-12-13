using System;

namespace split_timer_api.Entities
{
    public class Split : BaseEntity
    {
        public long Time { get; set; }
        public long SplitDefinitionId { get; set; }
        public long RunId { get; set; }
        public SplitDefinition SplitDefinition { get; set; }
        public Run Run { get; set; }
    }
}
