using System.ComponentModel.DataAnnotations;

namespace Major_Project.models
{
    public class Player
    {
        [MaxLength(20)]
        [MinLength(1)]
        public string UserName { get; set; } = null!;
        [MaxLength(6)]
        [MinLength(6)]
        public int Id { get; set; }
        public List<Item> items { get; set; }
        public List<Score> Scores { get; set; }
        public List<Data> Datas { get; set; }
        public List<Status> Statuses {get; set;}

    }
}