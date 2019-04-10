using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using FlexiMvvm.Bindings;
using FlexiMvvm.Collections;
using VacationsTracker.Core.Presentation.ViewModels.MainList;

namespace VacationsTracker.Droid.Views
{
    public partial class VacationRequestCellViewHolder :
        RecyclerViewBindableItemViewHolder<MainListViewModel, VacationRequestViewModel>
    {
        public VacationRequestCellViewHolder(View itemView)
            : base(itemView)
        {
            // TODO: create layout and update view holder
        }

        public override void Bind(BindingSet<VacationRequestViewModel> bindingSet)
        {
            base.Bind(bindingSet);

            bindingSet.Bind(DurationRange)
                .For(v => v.TextBinding())
                .To(vm => vm.DurationRange);

            bindingSet.Bind(VacationType)
                .For(v => v.TextBinding())
                .To(vm => vm.VacationTypeUI);
        }
    }
}