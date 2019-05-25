using System.Collections.Generic;
using System.Linq;
using VacationsTracker.Core.Communication;

namespace VacationsTracker.Core.Domain
{
    public static class VacationTypeIndexer
    {
        private static readonly IList<VacationType> _allValueableTypes;

        /// <summary>
        /// cctor() to cache valueable vacation types.
        /// </summary>
        static VacationTypeIndexer()
        {
            _allValueableTypes = VacationTypeExtensions
                .GetAllValueableTypes().
                ToList();
        }

        public static int VacationTypeToIndex(this VacationType vacationType) =>
            _allValueableTypes.IndexOf(vacationType);

        public static VacationType VacationTypeFromIndex(this int index) =>
            (0 <= index && index < _allValueableTypes.Count) ?
                 _allValueableTypes[index]
                 : VacationType.Undefined;
    }
}
