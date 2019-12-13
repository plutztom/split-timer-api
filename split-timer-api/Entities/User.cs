using System.Collections.Generic;

namespace split_timer_api.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<RunDefinition> RunDefinitions { get; set; }
    }
}
