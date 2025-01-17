using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lottogeneraattori.Models
{
    public class Lotterytickets
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int game_id { get; set; }
        [Required]
        public string game_name { get; set; }
        [Required]
        [Column(TypeName = "integer[]")]
        public int[] numbers { get; set; } = new int[7];

        public int playedgames { get; set; } // This is really stupid nobody cares about this data
    }
}
