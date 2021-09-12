using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Login_mobile
{
    [Activity(Label = "login_home")]
    public class login_home : Activity
    {
        Button btn_Account;
        Button btn_Agent;
        Button btn_Property;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            SetContentView(Resource.Layout.home_menu);

            btn_Account = FindViewById<Button>(Resource.Id.btn1);
            btn_Agent = FindViewById<Button>(Resource.Id.btn2);
            btn_Property = FindViewById<Button>(Resource.Id.btn3);

            btn_Account.Click += User_Account;
            btn_Agent.Click += Agent_Page;
            btn_Property.Click += Property_Page;

        }
        private void User_Account(object sender, EventArgs e)
        {
            StartActivity(typeof(EditUser));
        }
        private void Agent_Page(object sender, EventArgs e)
        {
            StartActivity(typeof(Home_Agent));
        }
        private void Property_Page(object sender, EventArgs e)
        {
            StartActivity(typeof(Home_Property));
        }
    }
}