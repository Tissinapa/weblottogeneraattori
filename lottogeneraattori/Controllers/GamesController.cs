using Microsoft.AspNetCore.Mvc;
using lottogeneraattori.Data;
using lottogeneraattori.Models;
using lottogeneraattori.Data;
using lottogeneraattori.Models;
using Microsoft.EntityFrameworkCore;



namespace lottogeneraattori.Controllers
{
    

    public class GamesController : Controller
    {
        private readonly LottoDbContext _context;

        private int[] GenerateNumbers(int amount, int min, int max)
        {
            var numbers = new int[amount];
            var rnd = new Random();
            for (int i = 0; i < amount; i++)
            {
                numbers[i] = rnd.Next(min, max);
            }
            Array.Sort(numbers);
            return numbers;
        }
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
        [HttpPost]
        public IActionResult PlayLotto(int[] userNumbers)
        {
            if (userNumbers.Length != 7)
            {
                ViewBag.ErrorMessage = "You must select 7 numbers";
                return View("Lotto");
            }

            var winnigNumbers = GenerateNumbers(7, 1, 30);
            

            return View();
        }

        [Route("Games/VikingLotto")]
        public IActionResult VikingLotto()
        {
            return View();

        }
        [HttpPost]
        public IActionResult PlayVikingLotto()
        {
            return View();

        }

        public IActionResult PlayEurojackpot()
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
