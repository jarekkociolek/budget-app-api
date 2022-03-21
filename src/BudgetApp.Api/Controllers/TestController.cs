using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace BudgetApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly IOptions<GeneralSettings> _generalSettings;

        public TestController(IOptions<GeneralSettings> generalSettings)
        {
            _generalSettings = generalSettings;
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_generalSettings.Value.ApplicationName);
        }
    }
}
