using FootballManager.API.DTOs;
using FootballManager.API.Models;

namespace FootballManager.API.Converters
{
    public static class TeamConverter
    {
        public static Team ToDatabaseModel(this TeamDto team)
        {
            return new Team
            {
                Name = team.Name,
                Year = team.Year,
                City = team.City
            };
        }

        public static TeamDto ToDto(this Team team)
        {
            return new TeamDto
            {
                Id = team.Id,
                Name = team.Name,
                Year = team.Year,
                City = team.City,
                Players = team.Players
                .Select(p => p.ToDto())
                .ToList()
            };
        }
    }
}
