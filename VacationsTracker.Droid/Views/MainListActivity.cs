using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using FlexiMvvm.Bindings;
using FlexiMvvm.ValueConverters;
using FlexiMvvm.Views;
using VacationsTracker.Core.Presentation.ViewModels.MainList;

namespace VacationsTracker.Droid.Views
{
    [Activity(
        Theme = "@style/MainListTheme",
        Label = "MainListActivity")]
    public class MainListActivity : BindableAppCompatActivity<MainListViewModel>
    {
        private MainListActivityViewHolder ViewHolder { get; set; }
        private MainListRecyclerAdapter RequestsAdapter { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_main_list);

            ViewHolder = new MainListActivityViewHolder(this);

            RequestsAdapter = new MainListRecyclerAdapter(ViewHolder.RecyclerView)
            {
                Items = ViewModel.VacationRequests
            };
            ViewHolder.RecyclerView.SetAdapter(RequestsAdapter);
            ViewHolder.RecyclerView.SetLayoutManager(new LinearLayoutManager(this));
        }

        public override void Bind(BindingSet<MainListViewModel> bindingSet)
        {
            base.Bind(bindingSet);

            bindingSet.Bind(RequestsAdapter)
                .For(v => v.ItemClickedBinding())
                .To(vm => vm.OpenVacationDetailsCommand);

            bindingSet.Bind(ViewHolder.ProgressBarWidget)
                .For(v => v.VisibilityBinding())
                .To(vm => vm.ProgressVisible)
                .WithConversion<VisibleGoneValueConverter>();

            //bindingSet.Bind(ViewHolder.ImageButtonWidget)
            //    .For(v => v.ItemClickedBinding())
            //    .To(vm => vm.NewRequestCommand);

            //iewHolder.ImageButtonWidget.ClickWeakSubscribe(OnNewRequest);
        }
    }
}