using FlexiMvvm.ViewModels;
using VacationsTracker.Core.Communication;

namespace VacationsTracker.Core.Presentation.ViewModels.MainList
{
    public class VacationTypeViewModel : ViewModel
    {
        private VacationType _vacationType;

        public VacationTypeViewModel(VacationType vacationType)
        {
            VacationType = vacationType;
        }

        public VacationType VacationType
        {
            get => _vacationType;
            set => SetValue(ref _vacationType, value);
        }

        public string VacationTypeUI
        {
            get => VacationType.GetVacationTypeUI();
        }
    }
}
