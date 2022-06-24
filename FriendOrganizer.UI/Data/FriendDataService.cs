using System.Data.Entity;
using System.Threading.Tasks;
using FriendOrganizer.Model;
using FriendOrganizer.DataAccess;

namespace FriendOrganizer.UI.Data
{
    public class FriendDataService : IFriendDataService
    {
        private FriendOrganizerDbContext _context;

        public FriendDataService(FriendOrganizerDbContext context)
        {
            _context = context;
        }

        public async Task<Friend> GetFriendByIdAsync(int Id)
        {
            return await _context.Friends.SingleAsync(f => f.Id == Id);

        }

        public bool HasChanges()
        {
            return _context.ChangeTracker.HasChanges();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
