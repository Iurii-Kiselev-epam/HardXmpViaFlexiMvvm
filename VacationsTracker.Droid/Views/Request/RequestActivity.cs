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
using FlexiMvvm.Views;
using VacationsTracker.Core.Domain;
using VacationsTracker.Core.Presentation.ViewModels.MainList;
using VacationsTracker.Droid.Extensions;
using VacationsTracker.Droid.ValueConverters;
using VacationsTracker.Droid.Views;
using Fragment = Android.Support.V4.App.Fragment;

namespace VacationsTracker.Droid.Views.Request
{
    [Activity(
        Theme = "@style/MainListTheme",
        Label = "RequestActivity")]
    public class RequestActivity : BindableAppCompatActivity<VacationRequestViewModel, VacationRequestParameters>
    {
        private RequestActivityViewHolder ViewHolder { get; set; }
        private FragmentPagerObservableAdapter VacationTypesAdapter { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_request);
            ViewHolder = new RequestActivityViewHolder(this);

            VacationTypesAdapter = new FragmentPagerObservableAdapter(SupportFragmentManager, PagesFactory)
            {
                Items = VacationRequestViewModel.AllValueableVacationTypes
            };
            ViewHolder.VacationTypesViewpager.Adapter = VacationTypesAdapter;
        }

        public override void Bind(BindingSet<VacationRequestViewModel> bindingSet)
        {
            base.Bind(bindingSet);

            //bindingSet.Bind(VacationTypesAdapter)
            //    .For(v => v.ItemsBinding())
            //    .To(vm => vm.AllValueableVacationTypes);

            //bindingSet.Bind(VacationType)
            //    .For(v => v.TextBinding())
            //    .To(vm => vm.VacationTypeUI);

            //bindingSet.Bind(ViewHolder.ImageViewWidget)
            //    .For(v => v.DrawableBinding())
            //    .To(vm => vm.VacationType)
            //    .WithConversion<VacationTypeDrawableConverter>();
        }

        private Fragment PagesFactory(object viewModelParameters)
        {
            var parametersBundle = new Bundle();
            //parametersBundle.PutParameters((ImageDetailsParameters)viewModelParameters);

            var fragment = new VacationTypeFragment
            {
                Arguments = parametersBundle
            };

            return fragment;
        }
    }
}