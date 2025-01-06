using Microsoft.AspNetCore.Mvc;
using lottogeneraattori.Data;
using lottogeneraattori.Models;
using Microsoft.EntityFrameworkCore;



namespace lottogeneraattori.Controllers
{
    

    public class GamesController : Controller
    {
        private LottoDbContext _context;

        public GamesController(LottoDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {   

            return View();
        }
        public IActionResult Lotto()
        {
            return View();
        }
        public IActionResult VikingLotto()
        {
            return View();
        }
        public IActionResult EuroJackpot()
        {
            return View();
        }
    }
}
