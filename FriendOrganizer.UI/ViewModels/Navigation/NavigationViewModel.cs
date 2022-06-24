using System.Linq;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Prism.Events;
using FriendOrganizer.UI.Events;
using FriendOrganizer.UI.Data.Lookups;

namespace FriendOrganizer.UI.ViewModels.Navigation
{
    public class NavigationViewModel : Observable, INavigationViewModel
    {
        #region Fields

        private IEventAggregator _eventAggregator;
        private IFriendLookupDataService _lookupDataService;

        #endregion



        #region Constructor

        public NavigationViewModel(IEventAggregator eventAggregator, IFriendLookupDataService lookupDataService)
        {
            _eventAggregator = eventAggregator;
            _lookupDataService = lookupDataService;

            Friends = new ObservableCollection<NavigationItemViewModel>();

            _eventAggregator.GetEvent<AfterFriendSavedEvent>().Subscribe(AfterFriendSaved);
        }

        #endregion



        #region Properties

        public ObservableCollection<NavigationItemViewModel> Friends { get; set; }

        #endregion



        #region Methods

        public async Task LoadAsync()
        {
            var lookupItems = await _lookupDataService.GetFriendsLookupAsync();

            Friends.Clear();

            foreach (var item in lookupItems)
                Friends.Add(new NavigationItemViewModel(item.Id, item.DisplayMember, _eventAggregator));

        }

        private void AfterFriendSaved(AfterFriendSavedEventArgs args)
        {
            var friend = Friends.Single(f => f.Id == args.Id);

            friend.DisplayMember = args.DisplayMember;
        }

        #endregion
    }
}
