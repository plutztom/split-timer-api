using System.Collections.Generic;

namespace split_timer_api.Entities
{
    public class SplitDefinition : BaseEntity
    {
        public string Name { get; set; }
        public int Order { get; set; }
        public long RunDefinitionId { get; set; }
        public RunDefinition RunDefinition { get; set; }
        public ICollection<Split> Splits { get; set; }
    }
}
