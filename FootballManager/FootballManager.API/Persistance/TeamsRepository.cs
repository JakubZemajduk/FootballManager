using FootballManager.API.Models;

namespace FootballManager.API.Persistance
{
    public interface ITeamsRepository
    {
        ICollection<Team> GetTeams();
    }

    public class TeamsRepository : ITeamsRepository
    {
        private readonly ApplicationDbContext _context;

        public TeamsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ICollection<Team> GetTeams()
        {
            return _context.Teams.ToList();
        }

    }
}
