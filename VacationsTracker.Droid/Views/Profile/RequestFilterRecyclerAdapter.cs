using Android.Support.V7.Widget;
using Android.Views;
using FlexiMvvm.Collections;

namespace VacationsTracker.Droid.Views.Profile
{
    public class RequestFilterRecyclerAdapter : RecyclerViewObservablePlainAdapter
    {
        public RequestFilterRecyclerAdapter(RecyclerView recyclerView)
            : base(recyclerView)
        {
        }

        protected override RecyclerViewObservableViewHolder OnCreateItemViewHolder(ViewGroup parent, int viewType)
        {
            var itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.cell_request_filter, parent, false);
            return new RequestFilterCellViewHolder(itemView);
        }
    }
}