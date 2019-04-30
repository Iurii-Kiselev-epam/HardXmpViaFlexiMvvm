using Android.Views;
using FlexiMvvm.Bindings;
using FlexiMvvm.Collections;
using VacationsTracker.Core.Presentation.ViewModels.Profile;

namespace VacationsTracker.Droid.Views
{
    public partial class RequestFilterCellViewHolder :
        RecyclerViewBindableItemViewHolder<ProfileViewModel, RequestFilterViewModel>
    {
        public RequestFilterCellViewHolder(View itemView)
            : base(itemView)
        {
        }

        public override void Bind(BindingSet<RequestFilterViewModel> bindingSet)
        {
            base.Bind(bindingSet);

            bindingSet.Bind(RequestUiFilter)
                .For(v => v.TextBinding())
                .To(vm => vm.UiFilter);
        }
    }
}