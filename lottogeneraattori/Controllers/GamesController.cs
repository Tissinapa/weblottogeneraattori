using Microsoft.AspNetCore.Mvc;
using lottogeneraattori.Data;
using lottogeneraattori.Models;
using Microsoft.EntityFrameworkCore;



namespace lottogeneraattori.Controllers
{
    

    public class GamesController : Controller
    {
        private readonly LottoDbContext _context;

        public GamesController(LottoDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {   

            return View();
        }
        [Route("Games/Lotto")]
        public IActionResult Lotto()
        {
            return View();
        }
        [Route("Games/VikingLotto")]
        public IActionResult VikingLotto()
        {
            return View();
        }
        [Route("Games/Eurojackpot")]
        public IActionResult Eurojackpot()
        {
            return View();
        }
    }
}
