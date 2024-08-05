using FootballManager.API.Models;

namespace FootballManager.API.Persistance
{
    public interface IPlayersRepository
    {
        ICollection<Player> GetPlayers();
        Player GetPlayerById(int playerId);

        IEnumerable<Player> GetPlayersByTeamId(int teamId);
        int Create(Player player);

        void Update(int id, Player player);

        void Delete(int id);

    }

    public class PlayersRepository : IPlayersRepository
    {
        private readonly ApplicationDbContext _context;

        public PlayersRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public int Create(Player player)
        {
            _context.Players.Add(player);
            _context.SaveChanges();
            return player.Id;
        }

        public void Delete(int id)
        {
            var toRemove = _context.Players.Where(r => r.Id == id).SingleOrDefault();
            if (toRemove == null)
            {
                return;
            }
            _context.Players.Remove(toRemove);
            _context.SaveChanges();
        }

        public ICollection<Player> GetPlayers()
        {
            return _context.Players.ToList();
        }

        public void Update(int id, Player player)
        {
            var toUpdate = _context.Players.Where(t => t.Id == id).SingleOrDefault();

            if (toUpdate == null)
            {
                return;
            }
            toUpdate.Name = player.Name;
            toUpdate.Year = player.Year;
            toUpdate.Surname = player.Surname;
            toUpdate.TeamId = player.TeamId;
            toUpdate.Position = player.Position;
            _context.SaveChanges();
        }
        public Player GetPlayerById(int id)
        {
            return _context.Players.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Player> GetPlayersByTeamId(int teamId)
        {
            return _context.Players.Where(p => p.TeamId == teamId).ToList();
        }
    }
}
