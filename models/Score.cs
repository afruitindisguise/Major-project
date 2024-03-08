using System.ComponentModel.DataAnnotations;

namespace Major_Project.models{
    public class Score{
        public int ScoreAmount { get; set; }
        [MaxLength(6)]
        [MinLength(6)]
        public int Id { get; set; }
        public List<int> Scores { get; set; } = [];
        public List<Player> Players { get; set; }
    }

}