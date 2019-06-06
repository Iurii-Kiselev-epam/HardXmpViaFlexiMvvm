using FlexiMvvm.ViewModels;
using System;

namespace VacationsTracker.Core.Domain
{
    public class VacationRequestParameters : Parameters
    {
        public Guid RequestId
        {
            get => (Guid.TryParse(Bundle.GetString(), out Guid result)) ? result : Guid.Empty;
            set => Bundle.SetString(value.ToString());
        }
    }
}
