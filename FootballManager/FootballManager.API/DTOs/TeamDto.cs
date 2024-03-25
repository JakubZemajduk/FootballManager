using FootballManager.API.Models;

namespace FootballManager.API.DTOs
{
    public class TeamDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string City { get; set; }
        public ICollection<PlayerDto> Players { get; set;}
    }
}
