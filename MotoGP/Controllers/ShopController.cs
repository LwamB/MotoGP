using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MotoGP.Data;
using MotoGP.Models;
using MotoGP.Models.ViewModels;

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

        public IActionResult ListTickets(int raceID = 0)
        {
            ViewData["BannerNr"] = 3;
            var selectTicketsVM = new SelectTicketsViewModel();

            selectTicketsVM.Races = new SelectList(_context.Races.OrderBy(m => m.Name).ToList(), "RaceID", "Name");

            if (raceID != 0)
            {
                selectTicketsVM.TicketList = _context.Tickets.Where(m => m.RaceID == raceID).OrderBy(m => m.Name).ToList();
            }
            return View(selectTicketsVM);

        }

        public IActionResult EditTicket(int id)
        {
            ViewData["BannerNr"] = 3;
            var ticket = _context.Tickets.Where(m => m.TicketID == id).Include(m => m.Country).Include(m => m.Race).FirstOrDefault();
            return View(ticket);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditTicket(int id, [Bind("TicketID, Paid")] Ticket ticket)
        {
            ViewData["BannerNr"] = 3;
            ticket.Paid = true;


            if (ModelState.IsValid)
            {
                try
                {
                    _context.Tickets.Attach(ticket);
                    _context.Entry(ticket).Property(m => m.Paid).IsModified = true;
                    _context.SaveChanges();
                }

                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction("ListTickets", new { id = ticket.TicketID });
            }
            return View(ticket);
        }


    }
}
