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
    [Activity(Label = "AddAgent_Activity")]
    public class AddAgent_Activity : Activity
    {
        Button btn_Add;
        EditText Agent_Name;
        EditText Agent_Email;
        EditText Agent_Mobile;
        EditText Office_Location;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.AddAgent);

            Agent_Name = FindViewById<EditText>(Resource.Id.AgentName);
            Agent_Email = FindViewById<EditText>(Resource.Id.AgentEmail);
            Agent_Mobile = FindViewById<EditText>(Resource.Id.AgentMobile);
            Office_Location = FindViewById<EditText>(Resource.Id.OfficeLocation);
            btn_Add = FindViewById<Button>(Resource.Id.btnAdd);
            btn_Add.Click += OnBtnAddClick;
        }
        private void OnBtnAddClick(object sender, EventArgs e)
        {
            if (Agent_Name.Text != "" && Agent_Email.Text != "" && Agent_Mobile.Text != "" && Office_Location.Text != "")
            {
                DatabaseManager.AddAgent(Agent_Name.Text, Agent_Email.Text, Agent_Mobile.Text, Office_Location.Text);
                Toast.MakeText(this, "New Agent data Added", ToastLength.Long).Show();
                this.Finish();
                StartActivity(typeof(Home_Agent));
            }
            else
            {
                Toast.MakeText(this, "Please fill data in all fields", ToastLength.Long).Show();
            }
        }
    }
}