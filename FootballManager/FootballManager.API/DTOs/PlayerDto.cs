using FootballManager.API.Models;

namespace FootballManager.API.DTOs
{
    public class PlayerDto
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Year { get; set; }
        public Positions Position { get; set; }
    }
}
