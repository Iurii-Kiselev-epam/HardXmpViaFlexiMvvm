using System;
using VacationsTracker.Core.Resources;

namespace VacationsTracker.Core.Communication
{
    public static class VacationStatusExtensions
    {
        public static string GetVacationStatusUI(this VacationStatus vacationStatus)
        {
            // to have possibility to localize resources
            switch(vacationStatus)
            {
                case VacationStatus.Draft:
                    return Strings.VacationStatus_Draft;
                case VacationStatus.Submitted:
                    return Strings.VacationStatus_Submitted;
                case VacationStatus.Approved:
                    return Strings.VacationStatus_Approved;
                case VacationStatus.InProgress:
                    return Strings.VacationStatus_InProgress;
                case VacationStatus.Closed:
                    return Strings.VacationStatus_Closed;

                default:
                    throw new ArgumentOutOfRangeException(nameof(vacationStatus));
            }
        }
    }
}
