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
            return Ok(_teamsRepository.GetTeams());
        }

        [HttpPost(Name = "CreateTeam")]
        public IActionResult Post([FromBody]Team team) 
        {
            return Ok(_teamsRepository.Create(team));
        }

        [HttpPut("{id}",Name = "PutTeam")]
        public IActionResult Put([FromRoute] int id, [FromBody] Team team)
        {
             _teamsRepository.Update(id, team);
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
