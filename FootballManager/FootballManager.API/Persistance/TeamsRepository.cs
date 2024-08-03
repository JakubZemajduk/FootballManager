using FootballManager.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FootballManager.API.Persistance
{
    public interface ITeamsRepository
    {
        ICollection<Team> GetTeams();
        Team GetTeamById(int teamId);

        int Create(Team team);

        void Update(int id, Team team);

        void Delete(int id);

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

        public void Delete(int id)
        {
            var toRemove = _context.Teams.Where(r => r.Id == id).SingleOrDefault();
            if (toRemove == null)
            {
                return;
            }
            _context.Teams.Remove(toRemove);
            _context.SaveChanges();
        }

        public ICollection<Team> GetTeams()
        {
            return _context.Teams.Include(t => t.Players).ToList();
        }

        public void Update(int id, Team team)
        {
            var toUpdate = _context.Teams.Where(t => t.Id == id).SingleOrDefault();

            if(toUpdate == null)
            {
                return;
            }
            toUpdate.Name = team.Name;
            toUpdate.Year = team.Year;
            toUpdate.City = team.City;
            _context.SaveChanges();
        }
        public Team GetTeamById(int id)
        {
            return _context.Teams.Where(t => t.Id == id).SingleOrDefault();
        }
    }
}
