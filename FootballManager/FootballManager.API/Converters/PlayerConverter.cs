using FootballManager.API.DTOs;
using FootballManager.API.Models;

namespace FootballManager.API.Converters
{
    public static class PlayerConverter
    {
        public static Player ToDatabaseModel (this PlayerDto player)
        {
            return new Player
            {
                Name = player.Name,
                Year = player.Year,
                Surname = player.Surname,
                TeamId = player.TeamId,
                Position = player.Position
            };  
        }

        public static PlayerDto ToDto(this Player player)
        {
            return new PlayerDto
            {
                Id = player.Id,
                Name = player.Name,
                Year = player.Year,
                Surname = player.Surname,
                TeamId = player.TeamId,
                Position = player.Position
            };
        }
    }
}
