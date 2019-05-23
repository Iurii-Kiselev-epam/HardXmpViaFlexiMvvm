using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlexiMvvm;
using FlexiMvvm.Bindings;
using FlexiMvvm.Views;
using Foundation;
using UIKit;
using VacationsTracker.Core.Domain;
using VacationsTracker.Core.Presentation.ViewModels.Request;
using VacationsTracker.Core.Resources;

namespace VacationsTracker.iOS.Views.Request
{
    public class RequestViewController : BindableViewController<EditableVacationRequestViewModel, VacationRequestParameters>
    {
        public RequestViewController(VacationRequestParameters parameters)
            : base(parameters)
        {
        }
        public new RequestView View
        {
            get => (RequestView)base.View.NotNull();
            set => base.View = value;
        }

        public override void LoadView() =>
            View = new RequestView();

        public override void Bind(BindingSet<EditableVacationRequestViewModel> bindingSet)
        {
            base.Bind(bindingSet);

            //bindingSet.Bind(View.ErrorTextLabel)
            //    .For(v => v.TextBinding())
            //    .To(vm => vm.ErrorMessage);
            //bindingSet.Bind(View.ErrorTextLabel)
            //    .For(v => v.HiddenBinding())
            //    .To(vm => vm.ErrorMessageVisible)
            //    .WithConversion<InvertValueConverter>();

            //bindingSet.Bind(View.LoginTextField)
            //    .For(v => v.TextAndEditingDidEndBinding())
            //    .To(vm => vm.Login);

            //bindingSet.Bind(View.PasswordTextField)
            //    .For(v => v.TextAndEditingDidEndBinding())
            //    .To(vm => vm.Password);

            //bindingSet.Bind(View.SignInButton)
            //      .For(v => v.TouchUpInsideBinding())
            //      .To(vm => vm.SignInCommand);
            //bindingSet.Bind(View.SignInButton)
            //    .For(v => v.HiddenBinding())
            //    .To(vm => vm.SignInVisible)
            //    .WithConversion<InvertValueConverter>();

            //bindingSet.Bind(View.ActivityIndicatorView)
            //    .For(v => v.ActivityBinding())
            //    .To(vm => vm.ProgressVisible)
            //    .WithConversion<InvertValueConverter>();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            NavigationController.NotNull().NavigationBarHidden = false;
            Title = Strings.Request_Title;
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
            HideKeyboard();
        }

        private void HideKeyboard() =>
            UIApplication.SharedApplication.KeyWindow.EndEditing(true);
    }
}