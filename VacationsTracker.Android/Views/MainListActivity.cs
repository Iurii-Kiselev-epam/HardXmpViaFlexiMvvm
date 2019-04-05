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
using FlexiMvvm.Views;
using VacationsTracker.Core.Presentation.ViewModels.MainList;

namespace VacationsTracker.Droid.Views
{
    [Activity(Label = "MainListActivity")]
    public class MainListActivity : BindableAppCompatActivity<MainListViewModel>
    {
        private MainListActivityViewHolder ViewHolder { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_main_list);

            ViewHolder = new MainListActivityViewHolder(this);
        }
    }
}