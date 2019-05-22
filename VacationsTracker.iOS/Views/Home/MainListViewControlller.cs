using FlexiMvvm;
using FlexiMvvm.Bindings;
using FlexiMvvm.Collections;
using FlexiMvvm.ValueConverters;
using FlexiMvvm.Views;
using VacationsTracker.Core.Domain;
using VacationsTracker.Core.Presentation.ViewModels.MainList;
using VacationsTracker.iOS.Infrastructure.Bindings;

namespace VacationsTracker.iOS.Views.Home
{
    public class MainListViewControlller : BindableViewController<MainListViewModel, RequestFilterParameters>
    {
        public MainListViewControlller(RequestFilterParameters parameters)
            : base(parameters)
        {
        }

        public TableViewObservablePlainSource VacationsSource { get; private set; }

        public new MainListView View
        {
            get => (MainListView)base.View.NotNull();
            set => base.View = value;
        }

        public override void LoadView() =>
            View = new MainListView();

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            Title = string.Empty;
            NavigationController.NotNull().SetNavigationBarHidden(false, false);

            ViewModel.UpdateCommand.Execute(null);
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            NavigationItem.SetHidesBackButton(true, false);

            VacationsSource = new TableViewObservablePlainSource(
                View.VacationsView,
                vm => VacationRequestViewCell.CellId);
            View.VacationsView.Source = VacationsSource;
        }

        public override void Bind(BindingSet<MainListViewModel> bindingSet)
        {
            base.Bind(bindingSet);

            bindingSet.Bind(View.ActivityIndicatorView)
                .For(v => v.ActivityBinding())
                .To(vm => vm.ProgressVisible)
                .WithConversion<InvertValueConverter>();

            bindingSet.Bind(VacationsSource)
                .For(v => v.ItemsBinding())
                .To(vm => vm.VacationRequests);

            bindingSet.Bind(View.VacationsView)
                .For(v => v.HiddenBinding())
                .To(vm => vm.IsUIVisible)
                .WithConversion<InvertValueConverter>();
        }
    }
}