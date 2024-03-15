namespace Major_Project.models{
    public class Status{
       public int Id { get; set; }
        public string name { get; set; } = null!;
        public int dmgPturn { get; set; }
        public bool applied { get; set; }
        public List<Player> players { get; set; }
    }
}