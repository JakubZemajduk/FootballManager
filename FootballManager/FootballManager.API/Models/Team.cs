namespace FootballManager.API.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string City { get; set; }
        public virtual ICollection<Player> Players { get; set;}

        public ICollection<Transfer> OutgoingTransfers { get; set; } = new List<Transfer>();
        public ICollection<Transfer> IncomingTransfers { get; set; } = new List<Transfer>();
    }
}
