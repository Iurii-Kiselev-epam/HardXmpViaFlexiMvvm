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
using FlexiMvvm.Bindings;
using FlexiMvvm.Views;
using VacationsTracker.Core.Presentation.ViewModels.Profile;

namespace VacationsTracker.Droid.Views.Profile
{
    [Activity(
        Theme = "@style/MainListTheme",
        Label = "ProfileActivity")]
    public class ProfileActivity : BindableAppCompatActivity<ProfileViewModel>
    {
        private ProfileActivityViewHolder ViewHolder { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_profile);
            ViewHolder = new ProfileActivityViewHolder(this);
        }

        public override void Bind(BindingSet<ProfileViewModel> bindingSet)
        {
            base.Bind(bindingSet);

            // TODO: bind to selected filter
            // ...
        }

        public override void OnBackPressed()
        {
            base.OnBackPressed();
        }

    }
}