using Microsoft.AspNetCore.Mvc;

namespace MotoGP.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult OrderTicket()
        {
            int BannerNr = 3;
            ViewData["BannerNr"] = BannerNr;
            return View();
        }

        public IActionResult ConfirmOrder()
        {
            int BannerNr = 3;
            ViewData["BannerNr"] = BannerNr;
            return View();
        }
    }
}
