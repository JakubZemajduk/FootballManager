using FootballManager.API.Models;
namespace FootballManager.API.DTOs
{
    public class TransferDto
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int TargetTeamId { get; set; }
        public int SourceTeamId { get; set; }
    }
}
