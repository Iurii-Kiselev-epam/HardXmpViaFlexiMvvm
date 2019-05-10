using Android.App;
using Android.OS;
using FlexiMvvm.Bindings;
using FlexiMvvm.Collections;
using FlexiMvvm.ValueConverters;
using FlexiMvvm.Views;
using System;
using VacationsTracker.Core.Domain;
using VacationsTracker.Core.Presentation.ViewModels.MainList;
using VacationsTracker.Core.Presentation.ViewModels.Request;
using VacationsTracker.Core.ValueConverters;
using VacationsTracker.Droid.ValueConverters;
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

            ViewHolder.StartDateLayout.Click += StartDateLayout_Click;
            ViewHolder.EndDateLayout.Click += EndDateLayout_Click;
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

            bindingSet.Bind(ViewHolder.StartDayView)
                .For(v => v.TextBinding())
                .To(vm => vm.StartDay);

            bindingSet.Bind(ViewHolder.StartMonthView)
                .For(v => v.TextBinding())
                .To(vm => vm.ShortStartMonth);

            bindingSet.Bind(ViewHolder.StartYearView)
                .For(v => v.TextBinding())
                .To(vm => vm.StartYear);

            bindingSet.Bind(ViewHolder.EndDayView)
                .For(v => v.TextBinding())
                .To(vm => vm.EndDay);

            bindingSet.Bind(ViewHolder.EndMonthView)
                .For(v => v.TextBinding())
                .To(vm => vm.ShortEndMonth);

            bindingSet.Bind(ViewHolder.EndYearView)
                .For(v => v.TextBinding())
                .To(vm => vm.EndYear);

            bindingSet.Bind(ViewHolder.RequestSaveView)
              .For(v => v.ClickBinding())
              .To(vm => vm.SaveCommand);

            bindingSet.Bind(ViewHolder.ProgressBarWidget)
                .For(v => v.VisibilityBinding())
                .To(vm => vm.ProgressVisible)
                .WithConversion<VisibleInvisibleValueConverter>();
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

        private void StartDateLayout_Click(object sender, EventArgs e)
        {
            var datePickerFragment = DatePickerFragment.NewInstance(
                ViewModel.Start, ViewModel.Start.AddYears(1), date => ViewModel.Start = date);
            datePickerFragment.Show(SupportFragmentManager, nameof(DatePickerFragment));
        }

        private void EndDateLayout_Click(object sender, EventArgs e)
        {
            var datePickerFragment = DatePickerFragment.NewInstance(
                ViewModel.End, ViewModel.End.AddYears(1), date => ViewModel.End = date);
            datePickerFragment.Show(SupportFragmentManager, nameof(DatePickerFragment));
        }
    }
}