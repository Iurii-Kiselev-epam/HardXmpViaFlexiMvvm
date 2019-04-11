using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using FlexiMvvm.Bindings;
using FlexiMvvm.Views;
using VacationsTracker.Core.Presentation.ViewModels.MainList;

namespace VacationsTracker.Droid.Views
{
    [Activity(Label = "MainListActivity")]
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

            // how to bind items?
            //bindingSet.Bind(RequestsAdapter)
            //    .For(v => v.Items)
            //    .To(vm => vm.VacationRequests);

            bindingSet.Bind(RequestsAdapter)
                .For(v => v.ItemClickedBinding())
                .To(vm => vm.OpenVacationDetailsCommand);
        }
    }
}