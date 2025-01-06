using lottogeneraattori.Models;
using Microsoft.EntityFrameworkCore;

namespace lottogeneraattori.Data
{
    public class LottoDbContext : DbContext
    {
        public LottoDbContext(DbContextOptions<LottoDbContext> options)
            : base(options)
        {
        }

        public DbSet<Lotterytickets> Games { get; set; }
    }
}
