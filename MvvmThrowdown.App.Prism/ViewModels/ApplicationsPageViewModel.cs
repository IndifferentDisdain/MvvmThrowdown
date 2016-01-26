using Prism.Windows.Mvvm;

namespace MvvmThrowdown.App.Prism.ViewModels
{
    public class ApplicationsPageViewModel
    {
        public ApplicationsPageViewModel()
        {
            DisplayText = "Coming soon!";
        }

        public string DisplayText { get; private set; }
    }
}
