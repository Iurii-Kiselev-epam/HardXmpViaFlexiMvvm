using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlexiMvvm;
using FlexiMvvm.Bindings;
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

        public new MainListView View
        {
            get => (MainListView)base.View.NotNull();
            set => base.View = value;
        }

        public override void LoadView() =>
            View = new MainListView();

        public override void Bind(BindingSet<MainListViewModel> bindingSet)
        {
            base.Bind(bindingSet);
        }
    }
}