using FlexiMvvm.ViewModels;
using System;
using VacationsTracker.Core.Communication;

namespace VacationsTracker.Core.Presentation.ViewModels.MainList
{
    public class VacationRequestViewModel : ViewModel
    {
        public VacationRequestViewModel(VacationRequest vacationRequest)
        {
            if (vacationRequest == null)
            {
                throw new ArgumentNullException(nameof(vacationRequest));
            }

            Id = vacationRequest.Id;
            Start = vacationRequest.Start;
            End = vacationRequest.End;
            VacationType = vacationRequest.VacationType;
            VacationStatus = vacationRequest.VacationStatus;
            CreatedBy = vacationRequest.CreatedBy;
            Created = vacationRequest.Created;
        }

        public Guid Id { get; }

        public DateTime Start { get; }

        public DateTime End { get; }

        public VacationType VacationType { get; }

        public VacationStatus VacationStatus { get; }

        public string CreatedBy { get; }

        public DateTime Created { get; }

    }
}
