using FlexiMvvm;
using FlexiMvvm.Bindings;
using FlexiMvvm.Collections;
using FlexiMvvm.Views;
using VacationsTracker.Core.Domain;
using VacationsTracker.Core.Presentation.ViewModels.MainList;

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
            NavigationController.NavigationBarHidden = true;

            ViewModel.UpdateCommand.Execute(null);
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            VacationsSource = new TableViewObservablePlainSource(
                View.VacationsView,
                vm => VacationRequestViewCell.CellId);
            View.VacationsView.Source = VacationsSource;
        }

        public override void Bind(BindingSet<MainListViewModel> bindingSet)
        {
            base.Bind(bindingSet);

            bindingSet.Bind(VacationsSource)
                .For(v => v.ItemsBinding())
                .To(vm => vm.VacationRequests);
        }
    }
}