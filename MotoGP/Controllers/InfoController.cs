using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MotoGP.Data;
using MotoGP.Models.ViewModels;

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

        public IActionResult SelectRace(int raceID = 0)
        {
            ViewData["BannerNr"] = 0;
            var selectRacesVM = new SelectRacesViewModel();
            selectRacesVM.Races = new SelectList(_context.Races.OrderBy(m => m.Name), "RaceID", "Name");
            if (raceID != 0)
            {
                selectRacesVM.Race = _context.Races.Find(raceID);
            }

            selectRacesVM.raceID = raceID;

            return View(selectRacesVM);
        }

        public IActionResult ListTeams()
        {
            ViewData["BannerNr"] = 0;
            var teams = _context.Teams.OrderBy(m => m.Name).Include(m => m.Riders).ToList();
            return View(teams);

        }

        public IActionResult ListTeamsRiders(int teamID = 0)
        {
            ViewData["BannerNr"] = 0;
            var listTeamsRidersVM = new ListTeamsRidersViewModel();
            listTeamsRidersVM.Teams = _context.Teams.OrderBy(m => m.Name).ToList();

            if (teamID != 0)
            {
                listTeamsRidersVM.Riders = _context.Riders.OrderBy(m => m.FirstName).Where(m => m.TeamID == teamID).ToList();

            }
            listTeamsRidersVM.teamID = teamID;
            return View(listTeamsRidersVM);
        }
    }
}
