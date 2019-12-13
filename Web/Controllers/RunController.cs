using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using split_timer_api.ViewModel;
using Web.Services;
using Web.ViewModel;

namespace split_timer_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class RunController : ControllerBase
    {
        private readonly IRunService _runService;

        public RunController(IRunService runService)
        {
            _runService = runService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetRunDefintion(int runDefinitionId)
        {
            return Ok(await _runService.GetRunDefinition(runDefinitionId));
        }
        
    }
}