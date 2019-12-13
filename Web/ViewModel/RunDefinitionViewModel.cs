using System.Collections.Generic;

namespace split_timer_api.ViewModel
{
    public class RunDefinitionViewModel
    {
        public string Game { get; set; }
        public string Category { get; set; }
        public List<SplitDefinitionViewModel> Splits { get; set; }
    }
}