using System.Windows.Input;
using System.Threading.Tasks;
using Prism.Events;
using Prism.Commands;
using FriendOrganizer.UI.Data;
using FriendOrganizer.UI.Events;
using FriendOrganizer.UI.Wrappers;

namespace FriendOrganizer.UI.ViewModels.FriendDetails
{
    public class FriendDetailsViewModel : Observable, IFriendDetailsViewModel
    {
        #region Fields

        private IEventAggregator _eventAggregator;
        private IFriendDataService _friendDataService;
        private FriendWrapper _friend;
        private bool _hasChanges;

        #endregion



        #region Constructor

        public FriendDetailsViewModel(IEventAggregator eventAggregator, IFriendDataService friendDataService)
        {
            _eventAggregator = eventAggregator;
            _friendDataService = friendDataService;

            SaveCommand = new DelegateCommand(OnSave_Execute, OnSave_CanExecute);
        }

        #endregion



        #region Properties

        public ICommand SaveCommand { get; }

        public FriendWrapper Friend
        {
            get { return _friend; }

            private set
            {
                _friend = value;
                OnPropertyChanged();
            }
        }

        public bool HasChanges
        {
            get { return _hasChanges; }
            set
            {
                if (_hasChanges != value)
                {
                    _hasChanges = value;
                    OnPropertyChanged();
                    ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
                }
            }
        }

        #endregion



        #region Methods

        public async Task LoadAsync(int id)
        {
            if (id == -1)
            {
                Friend = null;
            }
            else
            {
                var friendModel = await _friendDataService.GetFriendByIdAsync(id);

                Friend = new FriendWrapper(friendModel);

                Friend.PropertyChanged += (s, e) =>
                {
                    if (!HasChanges)  // as to not access the HasChanges() method every time there is a change
                        HasChanges = _friendDataService.HasChanges();

                    if (e.PropertyName == nameof(Friend.HasErrors))
                        ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
                };
            }

            ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
        }

        private bool OnSave_CanExecute()
        {
            return Friend != null &&
                   !Friend.HasErrors &&
                   HasChanges;
        }

        private async void OnSave_Execute()
        {
            await _friendDataService.SaveAsync();

            HasChanges = _friendDataService.HasChanges();

            _eventAggregator.GetEvent<AfterFriendSavedEvent>().Publish(
                new AfterFriendSavedEventArgs
                {
                    Id = Friend.Id,
                    DisplayMember = $"{Friend.FirstName} {Friend.LastName}"
                });
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