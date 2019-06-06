using System;
using System.Collections.Generic;
using VacationsTracker.Core.Resources;

namespace VacationsTracker.Core.Communication
{
    public static class VacationTypeExtensions
    {
        public static string GetVacationTypeUI(this VacationType vacationType)
        {
            // to have possibility to localize resources
            switch (vacationType)
            {
                case VacationType.Undefined:
                    return Strings.VacationType_Undefined;
                case VacationType.Regular:
                    return Strings.VacationType_Regular;
                case VacationType.Sick:
                    return Strings.VacationType_Sick;
                case VacationType.Exceptional:
                    return Strings.VacationType_Exceptional;
                case VacationType.LeaveWithoutPay:
                    return Strings.VacationType_LeaveWithoutPay;
                case VacationType.Overtime:
                    return Strings.VacationType_Overtime;

                default:
                    throw new ArgumentOutOfRangeException(nameof(vacationType));
            }
        }

        public static IEnumerable<VacationType> GetAllValueableTypes()
        {
            foreach (var vt in Enum.GetValues(typeof(VacationType)))
            {
                var vacationType = (VacationType)vt;
                if (vacationType != VacationType.Undefined)
                {
                    yield return vacationType;
                }
            }
        }
    }
}
