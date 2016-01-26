using System.Collections.Generic;
using System.Collections.ObjectModel;
using MvvmThrowdown.Contracts.Services;
using MvvmThrowdown.Models;
using Prism.Commands;
using Prism.Windows.AppModel;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;

namespace MvvmThrowdown.App.Prism.ViewModels
{
    public class UsersPageViewModel : ViewModelBase
    {
        private readonly IUserService _userService;

        public UsersPageViewModel(IUserService userService)
        {
            _userService = userService;
            UserSelected = new DelegateCommand<User>(SelectUser, u => Users != null && Users.Count > 0);
        }

        public override async void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            base.OnNavigatedTo(e, viewModelState);
            Users = new ObservableCollection<User>(await _userService.GetAllUsersAsync());
            UserSelected.RaiseCanExecuteChanged();
        }

        private void SelectUser(User user)
        {
            SelectedUser = user;
        }

        [RestorableState]
        public ObservableCollection<User> Users { get; set; }

        private User _selectedUser;

        [RestorableState]
        public User SelectedUser
        {
            get { return this._selectedUser; }
            set
            {
                SetProperty(ref this._selectedUser, value);
            }
        }

        public DelegateCommand<User> UserSelected { get; }

        
    }
}
