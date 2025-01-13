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

        public DbSet<Lotterytickets> Lottopelit { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lotterytickets>().ToTable("games");
        }
    }
}
