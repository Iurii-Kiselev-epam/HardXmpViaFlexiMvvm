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
using FlexiMvvm.Views;
using VacationsTracker.Core.Domain;
using VacationsTracker.Core.Presentation.ViewModels.MainList;
using VacationsTracker.Droid.Extensions;
using VacationsTracker.Droid.ValueConverters;
using VacationsTracker.Droid.Views;

namespace VacationsTracker.Droid.Views.Request
{
    [Activity(
        Theme = "@style/MainListTheme",
        Label = "RequestActivity")]
    public class RequestActivity : BindableAppCompatActivity<VacationRequestViewModel, VacationRequestParameters>
    {
        private RequestActivityViewHolder ViewHolder { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_request);
            ViewHolder = new RequestActivityViewHolder(this);
        }

        public override void Bind(BindingSet<VacationRequestViewModel> bindingSet)
        {
            base.Bind(bindingSet);

            //bindingSet.Bind(VacationType)
            //    .For(v => v.TextBinding())
            //    .To(vm => vm.VacationTypeUI);

            //bindingSet.Bind(ViewHolder.ImageViewWidget)
            //    .For(v => v.DrawableBinding())
            //    .To(vm => vm.VacationType)
            //    .WithConversion<VacationTypeDrawableConverter>();
        }
    }
}