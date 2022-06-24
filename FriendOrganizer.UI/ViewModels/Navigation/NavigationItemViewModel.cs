using System.Windows.Input;
using Prism.Events;
using Prism.Commands;
using FriendOrganizer.UI.Events;

namespace FriendOrganizer.UI.ViewModels.Navigation
{
    public class NavigationItemViewModel : Observable
    {
        #region Fields

        private string _displayMember;
        private IEventAggregator _eventAggregator;

        #endregion



        #region Constructor

        public NavigationItemViewModel(int id, string displayMember, IEventAggregator eventAggregator)
        {
            Id = id;
            DisplayMember = displayMember;
            _eventAggregator = eventAggregator;

            OpenFriendDetailsCommand = new DelegateCommand(OnOpenFriendDetails);
        }

        #endregion



        #region Properties

        public ICommand OpenFriendDetailsCommand { get; }

        public int Id { get; }

        public string DisplayMember
        {
            get { return _displayMember; }
            set
            {
                _displayMember = value;
                OnPropertyChanged();
            }
        }

        #endregion



        #region Methods

        private void OnOpenFriendDetails()
        {
            _eventAggregator.GetEvent<OpenFriendDetailsViewEvent>().Publish(Id);
        }

        #endregion
    }

}
