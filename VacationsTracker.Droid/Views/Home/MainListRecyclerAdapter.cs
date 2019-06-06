using Android.Support.V7.Widget;
using Android.Views;
using FlexiMvvm.Collections;

namespace VacationsTracker.Droid.Views.Home
{
    public class MainListRecyclerAdapter : RecyclerViewObservablePlainAdapter
    {
        public MainListRecyclerAdapter(RecyclerView recyclerView)
            : base(recyclerView)
        {
        }

        protected override RecyclerViewObservableViewHolder OnCreateItemViewHolder(ViewGroup parent, int viewType)
        {
            var itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.cell_vacation_request, parent, false);
            return new VacationRequestCellViewHolder(itemView);
        }
    }
}
