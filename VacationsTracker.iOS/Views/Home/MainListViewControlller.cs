using FlexiMvvm;
using FlexiMvvm.Bindings;
using FlexiMvvm.Collections;
using FlexiMvvm.ValueConverters;
using FlexiMvvm.Views;
using UIKit;
using VacationsTracker.Core.Domain;
using VacationsTracker.Core.Presentation.ViewModels.MainList;
using VacationsTracker.iOS.Infrastructure.Bindings;
using VacationsTracker.iOS.Theme;

namespace VacationsTracker.iOS.Views.Home
{
    public class MainListViewControlller : BindableViewController<MainListViewModel, RequestFilterParameters>
    {
        public MainListViewControlller(RequestFilterParameters parameters)
            : base(parameters)
        {
            ProfileBarButton = new UIBarButtonItem("\u2764", UIBarButtonItemStyle.Plain, null);
            PlusBarButton = new UIBarButtonItem("+", UIBarButtonItemStyle.Plain, null);
            PlusBarButton.SetTitleTextAttributes(new UITextAttributes
            {
                TextColor = UIColor.White,
                Font = AppTheme.Current.Fonts.TitleBold
            }, UIControlState.Normal);
        }

        public TableViewObservablePlainSource VacationsSource { get; private set; }

        public UIBarButtonItem ProfileBarButton { get; private set; } 
        public UIBarButtonItem PlusBarButton { get; private set; } 

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

            NavigationItem.LeftBarButtonItem = ProfileBarButton;
            NavigationItem.RightBarButtonItem = PlusBarButton;

            ViewModel.UpdateCommand.Execute(null);
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = ViewModel.UIFilter;
            NavigationController.NotNull().NavigationBarHidden = false;

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

            bindingSet.Bind(ProfileBarButton)
                .For(v => v.ClickedBinding())
                .To(vm => vm.OpenProfileCommand);

            bindingSet.Bind(PlusBarButton)
                .For(v => v.ClickedBinding())
                .To(vm => vm.NewRequestCommand);
        }
    }
}