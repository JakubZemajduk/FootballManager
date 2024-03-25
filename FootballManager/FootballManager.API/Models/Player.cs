namespace FootballManager.API.Models
{
    public class Player 
    { 
        public int Id { get; set; } 
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Year { get; set; }
        public Positions Position { get; set; }
    }
}
