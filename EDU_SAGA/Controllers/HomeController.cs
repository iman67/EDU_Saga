using EDU_SAGA.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace EDU_SAGA.Controllers
{
    [Route("Home")]
    public class HomeController : Controller
    {
        private readonly IOrchestrationService _orchestrationService;

        public HomeController(IOrchestrationService orchestrationService)
        {
            _orchestrationService = orchestrationService;
        }
        [Route("Index")]
        public IActionResult Index()
        {
            _orchestrationService.StartOrder().GetAwaiter().GetResult();
            return View();
        }
    }
}
