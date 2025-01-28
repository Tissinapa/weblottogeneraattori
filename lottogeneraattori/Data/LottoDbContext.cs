using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using lottogeneraattori.Models;
using Microsoft.EntityFrameworkCore;

namespace lottogeneraattori.Data
{
    public class LottoDbContext : IdentityDbContext<IdentityUser>
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
