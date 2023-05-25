using Microsoft.AspNetCore.Mvc;
using MotoGP.Data;

namespace MotoGP.Controllers
{
    public class InfoController : Controller
    {
        private readonly GPContext _context;
        public InfoController(GPContext context)
        {
            _context = context;
        }
        public IActionResult ListRaces()
        {

            var races = _context.Races.ToList();

            int BannerNr = 0;
            ViewData["BannerNr"] = BannerNr;
            return View(races);
        }

        public IActionResult BuildMap()
        {
            /* var race1 = new Race()
             {
                 RaceID = 1,
                 X = 517,
                 Y = 19,
                 Name = "Assen"
             };
             var race2 = new Race()
             {
                 RaceID = 2,
                 X = 859,
                 Y = 249,
                 Name = "Losail Circuit"
             };
             var race3 = new Race()
             {
                 RaceID = 3,
                 X = 194,
                 Y = 428,
                 Name = "Autódromo Termas de Río Hondo"
             };

             var races = new List<Race>() { race1, race2, race3 };

             ViewData["races"] = races;*/

            var races = _context.Races.ToList();
            int BannerNr = 0;
            ViewData["BannerNr"] = BannerNr;
            return View(races);

        }

        public IActionResult ShowRace(int id)
        {
            int BannerNr = 0;
            ViewData["BannerNr"] = BannerNr;
            var race = _context.Races.Where(a => a.RaceID == id).FirstOrDefault();
            return View(race);
        }

        public IActionResult ListRiders()
        {
            int BannerNr = 0;
            ViewData["BannerNr"] = BannerNr;
            var riders = _context.Riders.OrderBy(m => m.Number).ToList();
            return View(riders);

        }
    }
}
