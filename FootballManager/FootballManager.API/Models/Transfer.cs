namespace FootballManager.API.Models
{
    public class Transfer
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public Player Player { get; set; }

        public int SourceTeamId { get; set; }
        public Team SourceTeam { get; set; }
        public int TargetTeamId { get; set; }
        public Team TargetTeam { get; set; }
    }
}
