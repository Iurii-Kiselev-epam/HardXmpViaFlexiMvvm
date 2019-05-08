using FlexiMvvm.ViewModels;
using VacationsTracker.Core.Communication;

namespace VacationsTracker.Core.Presentation.ViewModels.MainList
{
    public class VacationTypeViewModel : ViewModel<VacationTypeParameters>
    {
        private VacationType _vacationType;

        public VacationTypeViewModel()
        {
        }

        public VacationTypeViewModel(VacationType vacationType)
        {
            VacationReason = vacationType;
        }

        public VacationType VacationReason
        {
            get => _vacationType;
            set => SetValue(ref _vacationType, value);
        }

        public string VacationTypeUI
        {
            get => VacationReason.GetVacationTypeUI();
        }

        public override void Initialize(VacationTypeParameters parameters)
        {
            base.Initialize(parameters);
            VacationReason = parameters.VacationReason;
        }
    }
}
