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
using VacationsTracker.Core.Presentation.ViewModels.Request;
using VacationsTracker.Core.ValueConverters;
using VacationsTracker.Droid.Extensions;
using VacationsTracker.Droid.ValueConverters;
using VacationsTracker.Droid.Views;
using Fragment = Android.Support.V4.App.Fragment;

namespace VacationsTracker.Droid.Views.Request
{
    [Activity(
        Theme = "@style/MainListTheme",
        Label = "RequestActivity")]
    public class RequestActivity : BindableAppCompatActivity<EditableVacationRequestViewModel, VacationRequestParameters>
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
                Items = ViewModel.AllValueableVacationTypes
            };
            ViewHolder.VacationTypesViewpager.Adapter = VacationTypesAdapter;
            ViewHolder.TabLayout.SetupWithViewPager(ViewHolder.VacationTypesViewpager);

            // temporary code for testing
            ViewHolder.FirstSplitterView.Click += View_Click;
        }

        public override void Bind(BindingSet<EditableVacationRequestViewModel> bindingSet)
        {
            base.Bind(bindingSet);

            bindingSet.Bind(ViewHolder.VacationTypesViewpager)
                .For(v => v.SetCurrentItemAndPageSelectedBinding())
                .To(vm => vm.VacationReason)
                .WithConversion<VacationTypeCurrentItemConverter>();

            bindingSet.Bind(ViewHolder.VacationStatusRadioGroup)
                .For(v => v.CheckAndCheckedChangeBinding())
                .To(vm => vm.VacationStatus)
                .WithConversion<VacationStatusValueConverter>();
        }

        private Fragment PagesFactory(object viewModelParameters)
        {
            var parametersBundle = new Bundle();
            if (viewModelParameters is VacationTypeParameters parameters)
            {
                parametersBundle.PutParameters(parameters);
            }
            else
            {
                // TODO: think about exception generation
                // ...
                return null;
            }
            var fragment = new VacationTypeFragment
            {
                Arguments = parametersBundle
            };
            return fragment;
        }

        private void View_Click(object sender, EventArgs e)
        {
            var datePickerFragment = DatePickerFragment.NewInstance(
                ViewModel.Start, ViewModel.Start.AddMonths(1), date => ViewModel.Start = date);
            datePickerFragment.Show(SupportFragmentManager, nameof(DatePickerFragment));
        }
    }
}