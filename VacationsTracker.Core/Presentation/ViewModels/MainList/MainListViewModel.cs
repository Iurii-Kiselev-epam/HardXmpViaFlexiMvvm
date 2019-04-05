using FlexiMvvm.Collections;
using FlexiMvvm.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VacationsTracker.Core.Communication;
using VacationsTracker.Core.Navigation;

namespace VacationsTracker.Core.Presentation.ViewModels.MainList
{
    public class MainListViewModel : ViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly IXmpProxy _xmpProxy;

        public MainListViewModel(
            INavigationService navigationService,
            IXmpProxy xmpProxy)
        {
            _navigationService = navigationService;
            _xmpProxy = xmpProxy;
            VacationRequests = new ObservableCollection<VacationRequestViewModel>();
        }

        public ObservableCollection<VacationRequestViewModel> VacationRequests
        {
            get;
        }

        public override void Initialize()
        {
            base.Initialize();

            try
            {
                var listResult = Task.Run(async () => await _xmpProxy.VtsVacationGetListAsync()).Result;
            }
            catch(Exception ex)
            {
                // TODO: log exception
            }
        }
    }
}
