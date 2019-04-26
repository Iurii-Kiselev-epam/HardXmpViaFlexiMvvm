using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.Widget;
using FlexiMvvm.Bindings;
using FlexiMvvm.ValueConverters;
using FlexiMvvm.Views;
using VacationsTracker.Core.Presentation.ViewModels.MainList;

namespace VacationsTracker.Droid.Views.Home
{
    [Activity(
        Theme = "@style/MainListTheme",
        Label = "MainListActivity")]
    public class MainListActivity : BindableAppCompatActivity<MainListViewModel>
    {
        private const string RequestFilterKey = "RequestFilterKey";

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

            ViewHolder.BottomNavigation.NavigationItemSelectedWeakSubscribe(OnNavigationItemSelected);
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

            bindingSet.Bind(ViewHolder.ImageButtonWidget)
                .For(v => v.ClickBinding())
                .To(vm => vm.NewRequestCommand);
            bindingSet.Bind(ViewHolder.ImageButtonWidget)
                .For(v => v.VisibilityBinding())
                .To(vm => vm.IsUIVisible)
                .WithConversion<VisibleGoneValueConverter>();

            bindingSet.Bind(ViewHolder.BottomNavigation)
                .For(v => v.VisibilityBinding())
                .To(vm => vm.IsUIVisible)
                .WithConversion<VisibleGoneValueConverter>();

            bindingSet.Bind(ViewHolder.RecyclerView)
                .For(v => v.VisibilityBinding())
                .To(vm => vm.IsUIVisible)
                .WithConversion<VisibleGoneValueConverter>();
        }

        protected override void OnStart()
        {
            base.OnStart();
        }

        protected override void OnResume()
        {
            base.OnResume();

            //ViewModel.UpdateContentCommand.Execute(null);

            // select first item
            if (ViewHolder.BottomNavigation.SelectedItemId != Resource.Id.navigation_list_menu_item)
            {
                ViewHolder.BottomNavigation.SelectedItemId = Resource.Id.navigation_list_menu_item;
            }
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
            ViewModel.ProgressVisible = false;
            outState.PutInt(RequestFilterKey, (int)ViewModel.Filter);
        }

        private void OnNavigationItemSelected(object sender, BottomNavigationView.NavigationItemSelectedEventArgs e)
        {
            if(e.Item.ItemId == Resource.Id.navigation_profile_menu_item)
            {
                ViewModel.OpenProfileCommand.Execute(null);
            }
        }

    }
}