using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MotoGP.Data;
using MotoGP.Models;

namespace MotoGP.Controllers
{
    public class ShopController : Controller
    {

        private readonly GPContext _context;

        public ShopController(GPContext context)
        {
            _context = context;
        }

        //GET: Tickets/OrderTicket/id
        public IActionResult OrderTicket()
        {
            int BannerNr = 3;
            ViewData["BannerNr"] = BannerNr;
            ViewData["Countries"] = new SelectList(_context.Countries.OrderBy(m => m.Name), "CountryID", "Name");
            ViewData["Races"] = _context.Races
                .OrderBy(m => m.Name).ToList();
            return View();
        }

        //POST: Tickets/OrderTicket/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult OrderTicket([Bind("TicketID, Name, Email, Address, Number, CountryID, RaceID")] Ticket ticket)
        {

            ticket.OrderDate = DateTime.Now;
            ticket.Paid = false;
            if (ModelState.IsValid)
            {
                _context.Add(ticket);
                _context.SaveChanges();
                return RedirectToAction("ConfirmOrder", new { id = ticket.TicketID });
            }
            return View(ticket);
        }

        public IActionResult ConfirmOrder(int id)
        {
            int BannerNr = 3;
            ViewData["BannerNr"] = BannerNr;
            var ticket = _context.Tickets.Include(m => m.Race).Include(m => m.Country).Where(m => m.TicketID == id).SingleOrDefault();
            return View(ticket);
        }


    }
}
