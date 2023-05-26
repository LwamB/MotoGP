using Microsoft.AspNetCore.Mvc.Rendering;

namespace MotoGP.Models.ViewModels
{
    public class SelectRacesViewModel
    {
        public SelectList Races { get; set; }
        public Race? Race { get; set; }

        public int raceID { get; set; }

    }
}
