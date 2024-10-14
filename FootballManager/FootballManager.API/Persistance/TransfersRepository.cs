using FootballManager.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FootballManager.API.Persistance
{
    public interface ITransfersRepository
    {
        IEnumerable<Transfer> GetTransfers();
        Transfer GetTransferById(int id);
        int CreateTransfer (Transfer transfer);
    }
    public class TransfersRepository : ITransfersRepository
    {
        private readonly ApplicationDbContext _context;

        public TransfersRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Transfer> GetTransfers()
        {
            return _context.Transfers
                .Include(t => t.Player)
                .Include(t => t.SourceTeam)
                .Include(t => t.TargetTeam)
                .ToList();
        }
        public Transfer GetTransferById(int id)
        {
            return _context.Transfers
                .Include(t => t.Player)
                .Include(t => t.SourceTeam)
                .Include(t => t.TargetTeam)
                .FirstOrDefault(t => t.Id == id);
        }
        public int CreateTransfer(Transfer transfer)
        {
            _context.Transfers.Add(transfer);
            _context.SaveChanges();
            return transfer.Id;
        }
    }
}
