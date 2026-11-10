using Microsoft.AspNetCore.Mvc;
using SCADA.web.Sevices;

namespace SCADA.web.Controllers
{
    public class SchemeController : Controller
    {
        private readonly LiveValuesCache _cache;
        private readonly SchemeConfigService _scheme;

        public SchemeController(LiveValuesCache cache, SchemeConfigService scheme)
        {
            _cache = cache;
            _scheme = scheme;
        }
        public IActionResult Index()
        {
            return View(_scheme.GetSensors());
        }

        [HttpGet]
        public IActionResult Current()
        {
            return Json(_cache.GetAll());
        }
    }
}
