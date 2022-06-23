using FriendOrganizer.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.Data
{
    public class FriendDataService : IFriendDataService
    {
        public IEnumerable<Friend> GetFriends()
        {
            List<Friend> friends = new List<Friend>();
            friends.Add(new Friend { Id = 1, FirstName = "Faris", LastName = "Hadziomerovic" });
            friends.Add(new Friend { Id = 2, FirstName = "John", LastName = "Doe" });
            friends.Add(new Friend { Id = 3, FirstName = "Jane", LastName = "Winters" });

            return friends;
        }        
    }
}
