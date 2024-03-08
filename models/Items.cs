namespace Major_Project.models{
    public class Item{
        public int Id { get; set; }
        public string ItemName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public List<Player> players { get; set; }
    }
}