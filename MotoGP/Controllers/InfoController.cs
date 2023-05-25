using Microsoft.AspNetCore.Mvc;
using MotoGP.Models;

namespace MotoGP.Controllers
{
    public class InfoController : Controller
    {
        public IActionResult ListRaces()
        {

            int BannerNr = 0;
            ViewData["BannerNr"] = BannerNr;
            return View();
        }

        public IActionResult BuildMap()
        {
            var race1 = new Race()
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

            ViewData["races"] = races;
            int BannerNr = 0;
            ViewData["BannerNr"] = BannerNr;
            return View();

        }
    }
}
