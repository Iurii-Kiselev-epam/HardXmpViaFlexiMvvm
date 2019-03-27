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
    }

}
// ReSharper restore All
