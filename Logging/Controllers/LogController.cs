using LoggingService.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace LoggingService.Controllers
{
    [Route("Log")]
    public class LogController : Controller
    {
        private readonly ILogService _logService;

        public LogController(ILogService logService)
        {
            _logService = logService;
        }
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
