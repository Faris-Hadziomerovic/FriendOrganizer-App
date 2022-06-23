using FriendOrganizer.Model;
using FriendOrganizer.UI.Data;
using FriendOrganizer.UI.Events;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.ViewModels
{
    public class NavigationViewModel : Observable
    {
        #region Fields

        private Friend _selectedFriend;
        private IEventAggregator _eventAggregator;
        private IFriendDataService _friendDataService;
        
        #endregion



        #region Constructor

        public NavigationViewModel(IEventAggregator eventAggregator, IFriendDataService friendDataService)
        {
            _eventAggregator = eventAggregator;
            _friendDataService = friendDataService;

            Friends = new ObservableCollection<Friend>(_friendDataService.GetFriends());
        }

        #endregion



        #region Properties

        public ObservableCollection<Friend> Friends { get; set; }

        public Friend SelectedFriend
        {
            get { return _selectedFriend; }
            set
            {
                _selectedFriend = value;
                OnPropertyChanged();

                _eventAggregator.GetEvent<OpenFriendDetailsViewEvent>().Publish(_selectedFriend);
            }
        }

        #endregion



        #region Methods
        #endregion
    }
}
