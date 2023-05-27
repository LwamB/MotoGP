using Microsoft.AspNetCore.Mvc.Rendering;

namespace MotoGP.Models.ViewModels
{
    public class SelectTicketsViewModel
    {

        public SelectList Races { get; set; }
        public List<Ticket>? TicketList { get; set; }

        public int raceID { get; set; }


    }
}
