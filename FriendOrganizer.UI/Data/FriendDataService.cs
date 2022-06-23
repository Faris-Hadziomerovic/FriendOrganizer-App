using FriendOrganizer.DataAccess;
using FriendOrganizer.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.Data
{
    public class FriendDataService : IFriendDataService
    {
        public IEnumerable<Friend> GetFriends()
        {
            using (var ctx = new FriendOrganizerDbContext())
            {
                return ctx.Friends.AsNoTracking().ToList();
            }            
        }        
    }
}
