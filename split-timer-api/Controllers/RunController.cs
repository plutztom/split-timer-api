using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using split_timer_api.ViewModel;

namespace split_timer_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class RunController
    {
        [HttpGet("[action]")]
        public ActionResult<RunDefinitionViewModel> GetRunDefintion(int RunDefinitionId)
        {
            return new RunDefinitionViewModel
            {
                Category = "Any%",
                Game = "Legend of Zelda: Windwaker",
                Splits = new List<SplitDefinitionViewModel>
                {
                    new SplitDefinitionViewModel
                    {
                        Name = "Wind Waker"
                    },
                    new SplitDefinitionViewModel
                    {
                        Name = "Forsaken Fortress 1"
                    },
                    new SplitDefinitionViewModel
                    {
                        Name = "Empty Bottle"
                    },

                    new SplitDefinitionViewModel
                    {
                        Name = "Ganon"
                    },
                }
            };
        }
    }
}