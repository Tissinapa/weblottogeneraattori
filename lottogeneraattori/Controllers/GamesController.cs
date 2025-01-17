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
        public async Task<IActionResult> PlayLotto(string userNumbers)
        {
            var userSelectedNumbers = userNumbers.Split(",").Select(int.Parse).ToArray();

            if(string.IsNullOrEmpty(userNumbers))
            {
                ViewBag.ErrorMessage = "Et antanut yhtään numeroa";
                return View("Lotto");
            }

            if (userSelectedNumbers.Length != 7)
            {
                ViewBag.ErrorMessage = "You must select 7 numbers";
                return View("Lotto");
            }

            // Generate winning numbers
            var winnigNumbers = GenerateNumbers(7, 1, 30);
            bool isWinner = userSelectedNumbers.OrderBy(x => x).SequenceEqual(winnigNumbers.OrderBy(x => x));
            int correctNumbers = userSelectedNumbers.Intersect(winnigNumbers).Count();

            var lotteryTicket = new Lotterytickets
            {
                game_id = 0,
                game_name = "Lotto",
                numbers = userSelectedNumbers,
                playedgames = 1
            };

            _context.Lottopelit.Add(lotteryTicket);
            await _context.SaveChangesAsync();

            ViewBag.WinningNumbers = winnigNumbers;
            ViewBag.UserNumbers = userSelectedNumbers;
            ViewBag.CorrectNumbers = correctNumbers;
            return View("Results");
        }
        

        [Route("Games/VikingLotto")]
        public IActionResult VikingLotto()
        {
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> PlayVikingLotto(string userNumbers)
        {
            var userSelectedNumbers = userNumbers.Split(",").Select(int.Parse).ToArray();

            if (userSelectedNumbers.Length != 6)
            {
                ViewBag.ErrorMessage = "You must select 6 numbers";
                return View("VikingLotto");
            }

            // Generate winning numbers
            var winnigNumbers = GenerateNumbers(6, 1, 48);
            bool isWinner = userSelectedNumbers.OrderBy(x => x).SequenceEqual(winnigNumbers.OrderBy(x => x));
            int correctNumbers = userSelectedNumbers.Intersect(winnigNumbers).Count();

            var lotteryTicket = new Lotterytickets
            {
                game_id = 0,
                game_name = "VikingLotto",
                numbers = userSelectedNumbers,
                playedgames = 1
            };

            _context.Lottopelit.Add(lotteryTicket);
            await _context.SaveChangesAsync();

            ViewBag.WinningNumbers = winnigNumbers;
            ViewBag.UserNumbers = userSelectedNumbers;
            ViewBag.CorrectNumbers = correctNumbers;
            return View("Results");
        }
        [Route("Games/Eurojackpot")]
        public IActionResult Eurojackpot()
        {

            return View();
        }


        public async Task<IActionResult> PlayEurojackpot(string userNumbers)
        {
            var userSelectedNumbers = userNumbers.Split(",").Select(int.Parse).ToArray();

            if (userSelectedNumbers.Length != 5)
            {
                ViewBag.ErrorMessage = "You must select 5 numbers";
                return View("Eurojackpot");
            }

            // Generate winning numbers
            var winnigNumbers = GenerateNumbers(5, 1, 50);
            bool isWinner = userSelectedNumbers.OrderBy(x => x).SequenceEqual(winnigNumbers.OrderBy(x => x));
            int correctNumbers = userSelectedNumbers.Intersect(winnigNumbers).Count();

            var lotteryTicket = new Lotterytickets
            {
                game_id = 0,
                game_name = "Eurojackpot",
                numbers = userSelectedNumbers,
                playedgames = 1
            };

            _context.Lottopelit.Add(lotteryTicket);
            await _context.SaveChangesAsync();

            ViewBag.WinningNumbers = winnigNumbers;
            ViewBag.UserNumbers = userSelectedNumbers;
            ViewBag.CorrectNumbers = correctNumbers;
            return View("Results");

        }
       
    }
}
