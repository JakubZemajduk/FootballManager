namespace FootballManager.API.DTOs
{
    public class TransferDto
    {
        public int PlayerId { get; set; }
        public int TargetTeamId { get; set; }
        public int SourceTeamId { get; set; }
    }
}
