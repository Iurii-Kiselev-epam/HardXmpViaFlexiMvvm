using Cirrious.FluentLayouts.Touch;
using FlexiMvvm.Bindings;
using FlexiMvvm.Collections;
using System;
using UIKit;
using VacationsTracker.Core.Presentation.ViewModels.Profile;

namespace VacationsTracker.iOS.Views.Profile
{
    public class RequestFilterViewCell : TableViewBindableItemCell<object, RequestFilterViewModel>
    {
        protected internal RequestFilterViewCell(IntPtr handle)
            : base(handle)
        {
        }

        public static string CellId => nameof(RequestFilterViewCell);

        public RequestFilterView View { get; private set; }

        public override void LoadView()
        {
            View = new RequestFilterView();

            ContentView.AddSubview(View);
            ContentView.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
            ContentView.AddConstraints(View.FullSizeOf(ContentView));

            Accessory = UITableViewCellAccessory.None;
        }

        public override void Bind(BindingSet<RequestFilterViewModel> bindingSet)
        {
            base.Bind(bindingSet);

            bindingSet.Bind(View.RequestUiFilterLabel)
                .For(v => v.TextBinding())
                .To(vm => vm.UiFilter);
        }
    }
}