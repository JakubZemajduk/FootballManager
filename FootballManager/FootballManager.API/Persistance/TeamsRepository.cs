using FootballManager.API.Models;

namespace FootballManager.API.Persistance
{
    public interface ITeamsRepository
    {
        ICollection<Team> GetTeams();

        int Create(Team team);

    }

    public class TeamsRepository : ITeamsRepository
    {
        private readonly ApplicationDbContext _context;

        public TeamsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public int Create(Team team)
        {
            _context.Teams.Add(team);
            _context.SaveChanges();
            return team.Id;
        }

        public ICollection<Team> GetTeams()
        {
            return _context.Teams.ToList();
        }

    }
}
