using System.ComponentModel.DataAnnotations;

namespace Major_Project.models
{
    public class Player
    {
        [Required]
        [MaxLength(20)]
        [MinLength(1)]
        public string UserName { get; set; } = null!;

        [MaxLength(6)]
        [MinLength(6)]
        public int Id { get; set; }
        public List<Item> items { get; set; }
        public List<Score> Scores { get; set; }
        public int DataId { get; set; }
        public Data Data { get; set; }
    }
}