using System.ComponentModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using MvvmThrowdown.App.Prism.ViewModels;
using MvvmThrowdown.Models;
using Prism.Windows.Mvvm;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace MvvmThrowdown.App.Prism.Views
{
    public sealed partial class UsersPage : SessionStateAwarePage, INotifyPropertyChanged
    {
        public UsersPage()
        {
            this.InitializeComponent();
            DataContextChanged += MainPage_DataContextChanged;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public UsersPageViewModel ConcreteDataContext => DataContext as UsersPageViewModel;

        private void MainPage_DataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ConcreteDataContext)));
        }

        private void MasterListView_OnItemClick(object sender, ItemClickEventArgs e)
            => ConcreteDataContext.UserSelected.Execute((User) e.ClickedItem);
    }
}
