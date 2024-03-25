using FootballManager.API.Converters;
using FootballManager.API.DTOs;
using FootballManager.API.Models;
using FootballManager.API.Persistance;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FootballManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamsRepository _teamsRepository;

        public TeamsController(ITeamsRepository teamsRepository)
        {
            _teamsRepository = teamsRepository;
        }

        [HttpGet(Name = "GetTeams")]
        public IActionResult Get()
        {
            var teams = _teamsRepository.GetTeams();
            var dtos = teams
                .Select(t => t.ToDto())
                .ToList();
            return Ok(dtos);
        }

        [HttpPost(Name = "CreateTeam")]
        public IActionResult Post([FromBody]TeamDto team) 
        {
            return Ok(_teamsRepository.Create(team.ToDatabaseModel()));
        }

        [HttpPut("{id}",Name = "PutTeam")]
        public IActionResult Put([FromRoute] int id, [FromBody] TeamDto team)
        {
             _teamsRepository.Update(id, team.ToDatabaseModel());
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteTeam")]
        public IActionResult Delete([FromRoute] int id)
        {
            _teamsRepository.Delete(id);
            return NoContent();
        }
    }
}
