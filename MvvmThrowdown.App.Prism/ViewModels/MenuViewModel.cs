using System.Collections.ObjectModel;
using System.Linq;
using Prism.Commands;
using Prism.Windows.AppModel;
using Prism.Windows.Navigation;

namespace MvvmThrowdown.App.Prism.ViewModels
{
    public class MenuViewModel
    {
        private readonly INavigationService _navigationService;
        private bool _canNavigateToUsers = false;
        private bool _canNavigateToApps = true;

        public MenuViewModel(INavigationService navigationService, IResourceLoader resourceLoader)
        {
            _navigationService = navigationService;

            Commands = new ObservableCollection<MenuItemViewModel>
            {
                new MenuItemViewModel
                {
                    DisplayName = resourceLoader.GetString(ResourceTokens.UsersMenuItemDisplayName),
                    FontIcon = "\ue8bd",
                    Command = new DelegateCommand(NavigateToMessagesView, () => _canNavigateToUsers)
                },
                new MenuItemViewModel
                {
                    DisplayName = resourceLoader.GetString(ResourceTokens.ApplicationsMenuItemDisplayName),
                    FontIcon = "\ue71d",
                    Command = new DelegateCommand(NavigateToContactsView, () => _canNavigateToApps)
                },
            };
        }

        public ObservableCollection<MenuItemViewModel> Commands { get; set; }

        private void NavigateToMessagesView()
        {
            if (!_canNavigateToUsers) return;
            if (!_navigationService.Navigate(PageTokens.UsersPage, null)) return;

            _canNavigateToUsers = false;
            _canNavigateToApps = true;

            RaiseCanExecuteChanged();
        }

        private void NavigateToContactsView()
        {
            if (!_canNavigateToApps) return;
            if (!_navigationService.Navigate(PageTokens.Applications, null)) return;

            _canNavigateToUsers = true;
            _canNavigateToApps = false;

            RaiseCanExecuteChanged();
        }

        private void RaiseCanExecuteChanged()
        {
            foreach (var delegateCommand in Commands.Select(item => item.Command as DelegateCommand))
            {
                delegateCommand?.RaiseCanExecuteChanged();
            }
        }
    }
}
