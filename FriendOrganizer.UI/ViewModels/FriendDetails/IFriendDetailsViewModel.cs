using System.Threading.Tasks;

namespace FriendOrganizer.UI.ViewModels.FriendDetails
{
    public interface IFriendDetailsViewModel
    {
        bool HasChanges { get; set; }

        Task LoadAsync(int id);
    }
}