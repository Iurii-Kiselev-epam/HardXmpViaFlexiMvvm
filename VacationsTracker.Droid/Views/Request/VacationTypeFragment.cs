﻿using Android.OS;
using Android.Views;
using FlexiMvvm.Bindings;
using FlexiMvvm.Views;
using VacationsTracker.Core.Presentation.ViewModels.MainList;
using VacationsTracker.Droid.Extensions;
using VacationsTracker.Droid.ValueConverters;

namespace VacationsTracker.Droid.Views.Request
{
    public class VacationTypeFragment : BindableFragment<VacationTypeViewModel, VacationTypeParameters>
    {
        private VacationTypeFragmentViewHolder ViewHolder
        {
            get;
            set;
        }

        public override View OnCreateView(LayoutInflater inflater,
            ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(
                Resource.Layout.fragment_vacation_type,
                container, false);
            ViewHolder = new VacationTypeFragmentViewHolder(view);
            return view;
        }

        public override void Bind(BindingSet<VacationTypeViewModel> bindingSet)
        {
            base.Bind(bindingSet);

            bindingSet.Bind(ViewHolder.ImageViewWidget)
                .For(v => v.DrawableBinding())
                .To(vm => vm.VacationReason)
                .WithConversion<VacationTypeDrawableConverter>();

            bindingSet.Bind(ViewHolder.VacationTypeTextView)
                .For(v => v.TextBinding())
                .To(vm => vm.VacationTypeUI);
        }
    }
}