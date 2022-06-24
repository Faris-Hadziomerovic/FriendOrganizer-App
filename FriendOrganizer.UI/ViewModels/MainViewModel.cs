using System;
using System.Windows;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Prism.Events;
using FriendOrganizer.UI.Events;
using FriendOrganizer.UI.Views.Services;
using FriendOrganizer.UI.ViewModels.Navigation;
using FriendOrganizer.UI.ViewModels.FriendDetails;

//using FriendOrganizer.Model;
//using FriendOrganizer.UI.Data;
//using FriendOrganizer.UI.Event;
//using FriendOrganizer.UI.Views.Services;

namespace FriendOrganizer.UI.ViewModels
{
    public class MainViewModel : Observable
    {
        #region Fields
        
        private IEventAggregator _eventAggregator;
        private IMessageDialogService _messageDialogService;
        private IFriendDetailsViewModel _friendDetailsViewModel;
        private Func<IFriendDetailsViewModel> _friendDetailsViewModel_Creator;

        #endregion



        #region Constructor

        public MainViewModel(INavigationViewModel navigationViewModel,
                             Func<IFriendDetailsViewModel> friendDetailsViewModel_Creator,
                             IEventAggregator eventAggregator,
                             IMessageDialogService messageDialogService)
        {

            _friendDetailsViewModel_Creator = friendDetailsViewModel_Creator;

            NavigationViewModel = navigationViewModel;

            _messageDialogService = messageDialogService;

            _eventAggregator = eventAggregator;

            _eventAggregator.GetEvent<OpenFriendDetailsViewEvent>().Subscribe(OnOpenFriendDetailView);
        }

        #endregion



        #region Properties

        public INavigationViewModel NavigationViewModel { get; }

        public IFriendDetailsViewModel FriendDetailsViewModel
        {
            get { return _friendDetailsViewModel; }
            private set
            {
                _friendDetailsViewModel = value;
                OnPropertyChanged();
            }
        }

        #endregion



        #region Methods

        public async Task NavigationLoadAsync() // this is the standard method for loading the NavigationViewModel
        {
            await NavigationViewModel.LoadAsync();
        }

        public async Task LoadFriendDetailsAsync(int friend_Id) // this is the standard method for loading the friendDetailViewModel
        {
            if (FriendDetailsViewModel != null && FriendDetailsViewModel.HasChanges)
            {
                var results = _messageDialogService.ShowDialog_OK_Cancle("You have unsaved changes! Navigate away?", "Question");

                if (results == MessageDialogResults.Cancel)
                    return;
            }

            FriendDetailsViewModel = _friendDetailsViewModel_Creator();

            await FriendDetailsViewModel.LoadAsync(friend_Id);
        }

        private async void OnOpenFriendDetailView(int friend_Id) // event fires this method 
        {
            await LoadFriendDetailsAsync(friend_Id);
        }

        #endregion
    }
}










