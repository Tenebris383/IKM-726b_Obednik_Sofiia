using Microsoft.AspNetCore.Mvc;
using SCADA.web.Data;
using SCADA.web.Sevices;

namespace SCADA.web.Controllers
{
    public class SchemeController : Controller
    {
        private readonly LiveValuesCache _cache;
        private readonly SchemeConfigService _scheme;
        private readonly ApplicationDbContext _db;

        public SchemeController(LiveValuesCache cache, SchemeConfigService scheme, ApplicationDbContext db)
        {
            _cache = cache;
            _scheme = scheme;
            _db = db;
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

        [HttpPost]

        public IActionResult Save()
        {
            foreach (var sensor in _cache.GetAll()) 
            {
                _db.SensorSamples.Add(new SensorSample
                {

                     Topic = sensor.Topic,
                     Value = sensor.Value,
                     Unit = sensor.Unit,
                     MeasuredAtUtc = sensor.MeasuredAtUtc

                });
            }

            _db.SaveChanges();

            return RedirectToAction("History");
        }

        public IActionResult History()
        {
            return View(_db.SensorSamples.OrderByDescending(s=>s.Id).Take(50).ToList());
        }

    }
}
