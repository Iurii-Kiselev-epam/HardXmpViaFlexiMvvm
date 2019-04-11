using Android.Support.V7.Widget;
using Android.Views;
using FlexiMvvm.Collections;
using System;

namespace VacationsTracker.Droid.Views
{
    public class MainListRecyclerAdapter : RecyclerViewObservablePlainAdapter
    {
        public MainListRecyclerAdapter(RecyclerView recyclerView)
            : base(recyclerView)
        {
        }

        protected override RecyclerViewObservableViewHolder OnCreateItemViewHolder(ViewGroup parent, int viewType)
        {
            try
            {
                var itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.cell_vacation_request, parent, false);
                return new VacationRequestCellViewHolder(itemView);

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
