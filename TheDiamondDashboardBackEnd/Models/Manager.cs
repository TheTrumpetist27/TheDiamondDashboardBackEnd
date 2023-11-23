namespace TheDiamondDashboardBackEnd.Models
{
    public class Manager
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ClubName { get; set; } = string.Empty;

        public Manager()
        {
            
        }

        public Manager(int id, string name, string clubName)
        {
            Id = id;
            Name = name;
            ClubName = clubName;
        }
    }
}
