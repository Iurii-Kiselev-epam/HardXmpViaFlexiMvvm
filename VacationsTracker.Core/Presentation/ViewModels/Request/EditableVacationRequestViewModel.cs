﻿using FlexiMvvm.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VacationsTracker.Core.Communication;
using VacationsTracker.Core.Domain;
using VacationsTracker.Core.Navigation;
using VacationsTracker.Core.Presentation.ViewModels.MainList;

namespace VacationsTracker.Core.Presentation.ViewModels.Request
{
    public class EditableVacationRequestViewModel : VacationRequestViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly IXmpProxy _xmpProxy;

        /// <summary>
        /// ctor() for details view.
        /// </summary>
        /// <param name="navigationService">navigation service</param>
        /// <param name="xmpProxy">xmp service proxy</param>
        public EditableVacationRequestViewModel(
            INavigationService navigationService,
            IXmpProxy xmpProxy)
            : base()
        {
            _navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));
            _xmpProxy = xmpProxy ?? throw new ArgumentNullException(nameof(xmpProxy));

            AllValueableVacationTypes = new ObservableCollection<VacationTypeParameters>();
            AllValueableVacationTypes.AddRange(VacationTypeExtensions
                .GetAllValueableTypes()
                .Select(vt => new VacationTypeParameters
                {
                    VacationReason = vt
                }));
        }

        public ObservableCollection<VacationTypeParameters> AllValueableVacationTypes { get; }

        public ICommand SaveCommand => CommandProvider.GetForAsync(Save);

        public override async Task InitializeAsync(VacationRequestParameters parameters)
        {
            await base.InitializeAsync(parameters);

            if (parameters.RequestId != Guid.Empty)
            {
                // TODO: get request from server
                try
                {
                    var result = await _xmpProxy.VtsVacationGetByIdAsync(parameters.RequestId.ToString());
                    GetDataFrom(result.Result);
                }
                catch (AuthenticationException authExc)
                {
                    // TODO: use authExc to log error
                    //ErrorMessage = UserConstants.Errors.AuthErrorMessage;
                }
                catch (CommunicationException cmnExc)
                {
                    // TODO: use cmnExc to log error
                    //ErrorMessage = UserConstants.Errors.CommunicationErrorMessage;
                }
                catch (Exception ex)
                {
                    // TODO: use ex to log error
                    //ErrorMessage = UserConstants.Errors.UnexpectedErrorMessage;
                }
            }
        }

        private async Task Save()
        {
            try
            {
                var vacationRequest = ToVacationRequest();
                await _xmpProxy.VtsVacationUpsertAsync(vacationRequest);

                // TODO: if operation suceeded
                // navigate to main list
                // ...
            }
            catch (AuthenticationException authExc)
            {
                // TODO: use authExc to log error
                //ErrorMessage = UserConstants.Errors.AuthErrorMessage;
            }
            catch (CommunicationException cmnExc)
            {
                // TODO: use cmnExc to log error
                //ErrorMessage = UserConstants.Errors.CommunicationErrorMessage;
            }
            catch (Exception ex)
            {
                // TODO: use ex to log error
                //ErrorMessage = UserConstants.Errors.UnexpectedErrorMessage;
            }
        }

    }
}
