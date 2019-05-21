using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlexiMvvm;
using FlexiMvvm.Bindings;
using FlexiMvvm.Collections;
using FlexiMvvm.ValueConverters;
using FlexiMvvm.Views;
using Foundation;
using UIKit;
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

        public CollectionViewObservablePlainSource VacationsSource { get; private set; }

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

            VacationsSource = new CollectionViewObservablePlainSource(
                View.VacationsView,
                vm => VacationRequestViewCell.CellId)
            {
                ItemsContext = ViewModel
            };

            View.VacationsView.DataSource = VacationsSource;

            //View.ResultsCollection.Delegate = new CustomFeedDelegateFlowLayout(
            //    ResultItemViewCell.Ratio,
            //    AppTheme.Current.Dimens.CollectionViewFooterDefaultHeight);
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