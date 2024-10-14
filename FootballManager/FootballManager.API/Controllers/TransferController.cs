using FootballManager.API.Converters;
using FootballManager.API.DTOs;
using FootballManager.API.Models;
using FootballManager.API.Persistance;
using Microsoft.AspNetCore.Mvc;

namespace FootballManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferController : ControllerBase
    {
        private readonly IPlayersRepository _playersRepository;
        private readonly ITransfersRepository _transfersRepository;

        public TransferController(ITransfersRepository transfersRepository, IPlayersRepository playersRepository)
        {
            _transfersRepository = transfersRepository;
            _playersRepository = playersRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Transfer>> GetTransfers()
        {
            var transfers = _transfersRepository.GetTransfers();
            var transferDtos = transfers.Select(t => t.ToDto()).ToList();
            return Ok(transferDtos);
        }

        [HttpGet("{id}")]
        public ActionResult<Transfer> GetTransferById(int id)
        {
            var transfer = _transfersRepository.GetTransferById(id);
            if(transfer == null)
            {
                return NotFound();
            }
            return Ok(transfer.ToDto());
        }

        [HttpPost]
        public ActionResult CreateTransfer([FromBody] TransferDto transferDto)
        { 
            var transfer = transferDto.ToDatabaseModel();

            var createdTransferId = _transfersRepository.CreateTransfer(transfer);

            var player = _playersRepository.GetPlayerById(transferDto.PlayerId);

            player.TeamId = transferDto.TargetTeamId;

            _playersRepository.Update(player.Id, player);

            return Ok(createdTransferId);
        }
    }
}
