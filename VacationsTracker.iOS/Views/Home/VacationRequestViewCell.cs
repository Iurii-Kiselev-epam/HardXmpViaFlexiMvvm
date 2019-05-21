using Cirrious.FluentLayouts.Touch;
using FlexiMvvm.Bindings;
using FlexiMvvm.Collections;
using System;
using VacationsTracker.Core.Presentation.ViewModels.MainList;
using VacationsTracker.iOS.Infrastructure.Bindings;
using VacationsTracker.iOS.Infrastructure.ValueConverters;

namespace VacationsTracker.iOS.Views.Home
{
    public class VacationRequestViewCell : CollectionViewBindableItemCell<object, VacationRequestViewModel>
    {
        protected internal VacationRequestViewCell(IntPtr handle)
            : base(handle)
        {
        }

        public static string CellId => nameof(VacationRequestViewCell);

        public VacationRequestView View { get; private set; }

        public override void LoadView()
        {
            View = new VacationRequestView();

            ContentView.AddSubview(View);
            ContentView.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
            ContentView.AddConstraints(View.FullSizeOf(ContentView));
        }

        public override void Bind(BindingSet<VacationRequestViewModel> bindingSet)
        {
            base.Bind(bindingSet);

            bindingSet.Bind(View.ImageCellView)
                .For(v => v.BundleImageBinding())
                .To(vm => vm.VacationReason)
                .WithConversion<VacationTypeImageIdConverter>();

            bindingSet.Bind(View.DurationRange)
                .For(v => v.TextBinding())
                .To(vm => vm.DurationRange);

            bindingSet.Bind(View.VacationType)
                .For(v => v.TextBinding())
                .To(vm => vm.VacationTypeUI);

            bindingSet.Bind(View.VacationStatus)
                .For(v => v.TextBinding())
                .To(vm => vm.VacationStatusUI);
        }
    }
}