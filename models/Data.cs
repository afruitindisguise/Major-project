
namespace Major_Project.models{
    public class Data{
        public int Id { get; set; }
        public int HP { get;  set;}
        public int MP { get; set; }
        public double AR { get; set; }
        public int location { get; set; }
        public List<Player> Players { get; set; }
    }
}