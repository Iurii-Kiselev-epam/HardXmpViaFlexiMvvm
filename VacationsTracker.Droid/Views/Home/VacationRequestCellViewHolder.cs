using Android.Views;
using FlexiMvvm.Bindings;
using FlexiMvvm.Collections;
using VacationsTracker.Core.Presentation.ViewModels.MainList;
using VacationsTracker.Droid.Extensions;
using VacationsTracker.Droid.ValueConverters;

namespace VacationsTracker.Droid.Views
{
    public partial class VacationRequestCellViewHolder :
        RecyclerViewBindableItemViewHolder<MainListViewModel, VacationRequestViewModel>
    {
        public VacationRequestCellViewHolder(View itemView)
            : base(itemView)
        {
        }

        public override void Bind(BindingSet<VacationRequestViewModel> bindingSet)
        {
            base.Bind(bindingSet);

            bindingSet.Bind(ImageCellView)
                .For(v => v.DrawableBinding())
                .To(vm => vm.VacationReason)
                .WithConversion<VacationTypeDrawableConverter>();

            bindingSet.Bind(DurationRange)
                .For(v => v.TextBinding())
                .To(vm => vm.DurationRange);

            bindingSet.Bind(VacationType)
                .For(v => v.TextBinding())
                .To(vm => vm.VacationTypeUI);

            bindingSet.Bind(VacationStatus)
                .For(v => v.TextBinding())
                .To(vm => vm.VacationStatusUI);
        }
    }
}