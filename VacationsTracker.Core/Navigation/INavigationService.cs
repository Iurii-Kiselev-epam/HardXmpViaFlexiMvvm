using VacationsTracker.Core.Presentation.ViewModels;

namespace VacationsTracker.Core.Navigation
{
    public interface INavigationService
    {
        void NavigateToLogin(EntryViewModel fromViewModel);
    }
}
