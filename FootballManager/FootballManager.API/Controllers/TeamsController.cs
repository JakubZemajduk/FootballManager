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
    }
}
