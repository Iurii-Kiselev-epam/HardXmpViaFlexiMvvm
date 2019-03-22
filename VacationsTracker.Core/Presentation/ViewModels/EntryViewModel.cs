using FlexiMvvm;
using FlexiMvvm.ViewModels;
using VacationsTracker.Core.Navigation;

namespace VacationsTracker.Core.Presentation.ViewModels
{
    public class EntryViewModel : ViewModel
    {
        private readonly INavigationService _navigationService;

        public EntryViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Initialize()
        {
            base.Initialize();

            _navigationService.NavigateToLogin(this);
        }
    }
}
