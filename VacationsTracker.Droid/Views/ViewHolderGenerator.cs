﻿// <auto-generated />
// ReSharper disable All
using System;
using Android.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace VacationsTracker.Droid.Views
{
    public partial class LoginActivityViewHolder
    {
         private readonly Activity activity;

         private TextView errorTextView;
         private EditText loginEditText;
         private EditText passwordEditText;
         private Button signInButton;
         private ProgressBar progressBarWidget;

        public LoginActivityViewHolder( Activity activity)
        {
            if (activity == null) throw new ArgumentNullException(nameof(activity));

            this.activity = activity;
        }

        
        public TextView ErrorTextView =>
            errorTextView ?? (errorTextView = activity.FindViewById<TextView>(Resource.Id.error_text_view));

        
        public EditText LoginEditText =>
            loginEditText ?? (loginEditText = activity.FindViewById<EditText>(Resource.Id.login_edit_text));

        
        public EditText PasswordEditText =>
            passwordEditText ?? (passwordEditText = activity.FindViewById<EditText>(Resource.Id.password_edit_text));

        
        public Button SignInButton =>
            signInButton ?? (signInButton = activity.FindViewById<Button>(Resource.Id.sign_in_button));

        
        public ProgressBar ProgressBarWidget =>
            progressBarWidget ?? (progressBarWidget = activity.FindViewById<ProgressBar>(Resource.Id.progress_bar_widget));
    }

    public partial class MainListActivityViewHolder
    {
         private readonly Activity activity;

         private Android.Support.V7.Widget.Toolbar toolbar;
         private TextView filterTextView;
         private ProgressBar progressBarWidget;
         private Android.Support.V7.Widget.RecyclerView recyclerView;
         private ImageButton imageButtonWidget;
         private Android.Support.Design.Widget.BottomNavigationView bottomNavigation;

        public MainListActivityViewHolder( Activity activity)
        {
            if (activity == null) throw new ArgumentNullException(nameof(activity));

            this.activity = activity;
        }

        
        public Android.Support.V7.Widget.Toolbar Toolbar =>
            toolbar ?? (toolbar = activity.FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar));

        
        public TextView FilterTextView =>
            filterTextView ?? (filterTextView = activity.FindViewById<TextView>(Resource.Id.filter_text_view));

        
        public ProgressBar ProgressBarWidget =>
            progressBarWidget ?? (progressBarWidget = activity.FindViewById<ProgressBar>(Resource.Id.progress_bar_widget));

        
        public Android.Support.V7.Widget.RecyclerView RecyclerView =>
            recyclerView ?? (recyclerView = activity.FindViewById<Android.Support.V7.Widget.RecyclerView>(Resource.Id.recycler_view));

        
        public ImageButton ImageButtonWidget =>
            imageButtonWidget ?? (imageButtonWidget = activity.FindViewById<ImageButton>(Resource.Id.image_button_widget));

        
        public Android.Support.Design.Widget.BottomNavigationView BottomNavigation =>
            bottomNavigation ?? (bottomNavigation = activity.FindViewById<Android.Support.Design.Widget.BottomNavigationView>(Resource.Id.bottom_navigation));
    }

    public partial class ProfileActivityViewHolder
    {
         private readonly Activity activity;

         private Android.Support.V7.Widget.RecyclerView recyclerView;
         private TextView profileNameTextView;
         private ImageView imageViewWidget;

        public ProfileActivityViewHolder( Activity activity)
        {
            if (activity == null) throw new ArgumentNullException(nameof(activity));

            this.activity = activity;
        }

        
        public Android.Support.V7.Widget.RecyclerView RecyclerView =>
            recyclerView ?? (recyclerView = activity.FindViewById<Android.Support.V7.Widget.RecyclerView>(Resource.Id.recycler_view));

        
        public TextView ProfileNameTextView =>
            profileNameTextView ?? (profileNameTextView = activity.FindViewById<TextView>(Resource.Id.profile_name_text_view));

        
        public ImageView ImageViewWidget =>
            imageViewWidget ?? (imageViewWidget = activity.FindViewById<ImageView>(Resource.Id.image_view_widget));
    }

    public partial class RequestFilterCellViewHolder
    {
         private TextView requestUiFilter;



        
        public TextView RequestUiFilter =>
            requestUiFilter ?? (requestUiFilter = ItemView.FindViewById<TextView>(Resource.Id.request_ui_filter));
    }

    public partial class VacationRequestCellViewHolder
    {
         private View backgroundCellView;
         private ImageView imageCellView;
         private TextView durationRange;
         private TextView vacationType;
         private TextView vacationStatus;



        
        public View BackgroundCellView =>
            backgroundCellView ?? (backgroundCellView = ItemView.FindViewById<View>(Resource.Id.background_cell_view));

        
        public ImageView ImageCellView =>
            imageCellView ?? (imageCellView = ItemView.FindViewById<ImageView>(Resource.Id.image_cell_view));

        
        public TextView DurationRange =>
            durationRange ?? (durationRange = ItemView.FindViewById<TextView>(Resource.Id.duration_range));

        
        public TextView VacationType =>
            vacationType ?? (vacationType = ItemView.FindViewById<TextView>(Resource.Id.vacation_type));

        
        public TextView VacationStatus =>
            vacationStatus ?? (vacationStatus = ItemView.FindViewById<TextView>(Resource.Id.vacation_status));
    }

}
// ReSharper restore All
