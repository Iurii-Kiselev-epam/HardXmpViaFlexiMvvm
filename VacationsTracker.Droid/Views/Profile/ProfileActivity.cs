using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using FlexiMvvm.Bindings;
using FlexiMvvm.Views;
using VacationsTracker.Core.Domain;
using VacationsTracker.Core.Presentation.ViewModels.Profile;

namespace VacationsTracker.Droid.Views.Profile
{
    [Activity(
        Theme = "@style/MainListTheme",
        Label = "ProfileActivity")]
    public class ProfileActivity : BindableAppCompatActivity<ProfileViewModel, RequestFilterParameters>
    {
        private ProfileActivityViewHolder ViewHolder { get; set; }
        private RequestFilterRecyclerAdapter FiltersAdapter { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_profile);
            ViewHolder = new ProfileActivityViewHolder(this);

            FiltersAdapter = new RequestFilterRecyclerAdapter(ViewHolder.RecyclerView)
            {
                Items = ViewModel.Filters
            };
            ViewHolder.RecyclerView.SetAdapter(FiltersAdapter);
            ViewHolder.RecyclerView.SetLayoutManager(new LinearLayoutManager(this));
        }

        public override void Bind(BindingSet<ProfileViewModel> bindingSet)
        {
            base.Bind(bindingSet);

            bindingSet.Bind(ViewHolder.FilterTextView)
                .For(v => v.TextBinding())
                .To(vm => vm.UIFilter);

            bindingSet.Bind(FiltersAdapter)
                .For(v => v.ItemClickedBinding())
                .To(vm => vm.OpenFilterCommand);
        }
    }
}