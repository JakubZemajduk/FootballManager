﻿using FootballManager.API.Converters;
using FootballManager.API.DTOs;
using FootballManager.API.Models;
using FootballManager.API.Persistance;
using Microsoft.AspNetCore.Mvc;

namespace FootballManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayersRepository _playersRepository;
        private readonly ITeamsRepository _teamsRepository;
        public PlayersController(IPlayersRepository playersRepository, ITeamsRepository teamsRepository)
        {
            _playersRepository = playersRepository;
            _teamsRepository = teamsRepository;
        }

        [HttpGet(Name = "GetPlayers")]
        public IActionResult Get()
        {
            var players = _playersRepository.GetPlayers();
            var dtos = players
                .Select(t => t.ToDto())
                .ToList();
            return Ok(dtos);
        }

        [HttpPost(Name = "CreatePlayer")]
        public IActionResult Post([FromBody] PlayerDto player)
        {
            return Ok(_playersRepository.Create(player.ToDatabaseModel()));
        }

        [HttpPut("{id}", Name = "PutPlayer")]
        public IActionResult Put([FromRoute] int id, [FromBody] PlayerDto player)
        {
            _playersRepository.Update(id, player.ToDatabaseModel());
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeletePlayer")]
        public IActionResult Delete([FromRoute] int id)
        {
            _playersRepository.Delete(id);
            return NoContent();
        }

        [HttpGet("team/{teamId}", Name = "GetPlayersByTeam")]
        public IActionResult GetPlayersByTeam(int teamId)
        {
            var players = _playersRepository.GetPlayersByTeamId(teamId);
            var dtos = players
                .Select(p => p.ToDto())
                .ToList();
            return Ok(dtos);
        }
    }
}
