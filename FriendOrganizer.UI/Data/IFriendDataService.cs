using FriendOrganizer.Model;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.Data
{
    public interface IFriendDataService
    {
        Task<Friend> GetFriendByIdAsync(int Id);
        bool HasChanges();
        Task SaveAsync();
    }
}