using FlexiMvvm.ViewModels;
using VacationsTracker.Core.Communication;

namespace VacationsTracker.Core.Presentation.ViewModels.MainList
{
    public class VacationTypeParameters : Parameters
    {
        public VacationType VacationReason
        {
            get => Bundle.GetEnum<VacationType>();
            set => Bundle.SetEnum(value);
        }
    }
}
