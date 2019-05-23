using FlexiMvvm;
using FlexiMvvm.Bindings;
using FlexiMvvm.Collections;
using FlexiMvvm.Views;
using UIKit;
using VacationsTracker.Core.Domain;
using VacationsTracker.Core.Presentation.ViewModels.Profile;

namespace VacationsTracker.iOS.Views.Profile
{
    public class ProfileViewController : BindableViewController<ProfileViewModel, RequestFilterParameters>
    {
        public ProfileViewController(RequestFilterParameters parameters)
            : base(parameters)
        {
        }

        public TableViewObservablePlainSource FiltersSource { get; private set; }

        public new ProfileView View
        {
            get => (ProfileView)base.View.NotNull();
            set => base.View = value;
        }

        public override void LoadView() =>
            View = new ProfileView();

        public override void Bind(BindingSet<ProfileViewModel> bindingSet)
        {
            base.Bind(bindingSet);

            bindingSet.Bind(FiltersSource)
                .For(v => v.ItemsBinding())
                .To(vm => vm.Filters);
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            NavigationController.NotNull().NavigationBarHidden = false;
            Title = ViewModel.UIFilter;

            FiltersSource = new TableViewObservablePlainSource(
                View.FiltersView,
                vm => RequestFilterViewCell.CellId);
            View.FiltersView.Source = FiltersSource;
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