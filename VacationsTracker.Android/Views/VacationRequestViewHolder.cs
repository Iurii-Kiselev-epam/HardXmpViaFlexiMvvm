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
using FlexiMvvm.Collections;
using VacationsTracker.Core.Presentation.ViewModels.MainList;

namespace VacationsTracker.Droid.Views
{
    public partial class VacationRequestViewHolder : RecyclerViewBindableItemViewHolder<MainListViewModel, VacationRequestViewModel>
    {
        public VacationRequestViewHolder(View itemView)
            : base(itemView)
        {
            // TODO: create layout and update view holder
        }
    }
}