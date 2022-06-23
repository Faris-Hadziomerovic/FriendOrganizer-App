using FriendOrganizer.Model;
using FriendOrganizer.UI.Events;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FriendOrganizer.UI.ViewModels
{
    public class FriendDetailsViewModel : Observable
    {
        #region Fields

        private IEventAggregator _eventAggregator;
        private Friend _friend;

        #endregion



        #region Constructor
        public FriendDetailsViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;

            SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExecute);

            _eventAggregator.GetEvent<OpenFriendDetailsViewEvent>().Subscribe(OnOpenFriendDetailsView);
        }

        #endregion



        #region Properties

        public ICommand SaveCommand { get; }

        public Friend Friend
        {
            get { return _friend; }
            set
            {
                _friend = value;
                OnPropertyChanged();
            }
        }

        #endregion



        #region Methods

        private void OnOpenFriendDetailsView(Friend args)
        {
            Friend = args;
        }

        private async void OnSaveExecute()
        {
            
        }

        private bool OnSaveCanExecute()
        {
            return true;
        }

        #endregion
    }
}


//#region Fields
//#endregion



//#region Constructor
//#endregion



//#region Properties
//#endregion



//#region Methods
//#endregion