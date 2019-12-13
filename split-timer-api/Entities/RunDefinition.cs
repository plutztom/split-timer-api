using System.Collections.Generic;

namespace split_timer_api.Entities
{
    public class RunDefinition : BaseEntity
    {
        public string Name { get; set; }
        public string Game { get; set; }
        public string Category { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
        public ICollection<SplitDefinition> SplitDefinitions { get; set; }
        public ICollection<Run> Runs { get; set; }
    }
}
