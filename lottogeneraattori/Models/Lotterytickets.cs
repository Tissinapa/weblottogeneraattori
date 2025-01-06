using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lottogeneraattori.Models
{
    public class Lotterytickets
    {

        [Key]
        public int GameId { get; set; }
        [Required]
        public string gameName { get; set; }
        [Required]
        [Column(TypeName = "integer[]")]
        public int[] Numbers { get; set; } = new int[7];

        public int PlayedGames { get; set; }
    }
}
