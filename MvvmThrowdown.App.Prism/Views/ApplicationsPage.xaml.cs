using System.ComponentModel;
using Windows.UI.Xaml;
using MvvmThrowdown.App.Prism.ViewModels;
using Prism.Windows.Mvvm;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace MvvmThrowdown.App.Prism.Views
{
    public sealed partial class ApplicationsPage : SessionStateAwarePage, INotifyPropertyChanged
    {
        public ApplicationsPage()
        {
            this.InitializeComponent();
            DataContextChanged += SecondPage_DataContextChanged;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ApplicationsPageViewModel ConcreteDataContext => DataContext as ApplicationsPageViewModel;

        private void SecondPage_DataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ConcreteDataContext)));
        }
    }
}
