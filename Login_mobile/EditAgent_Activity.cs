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
    [Activity(Label = "EditAgent_Activity")]
    public class EditAgent_Activity : Activity
    {
        int AgentId;
        TextView AgentName;
        TextView AgentEmail;
        TextView AgentMobile;
        TextView OfficeLocation;

        Button btn_Edit;
        Button btn_Delete;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.EditProperty);

            AgentName = FindViewById<TextView>(Resource.Id.AgentName);
            AgentEmail = FindViewById<TextView>(Resource.Id.AgentEmail);
            AgentMobile = FindViewById<TextView>(Resource.Id.AgentMobile);
            OfficeLocation = FindViewById<TextView>(Resource.Id.OfficeLocation);

            btn_Edit = FindViewById<Button>(Resource.Id.btnEdit);
            btn_Delete = FindViewById<Button>(Resource.Id.btnDelete);

            AgentId = Intent.GetIntExtra("AgentId", -1); //-1 is default 
            AgentName.Text = Intent.GetStringExtra("Agent Name");
            AgentEmail.Text = Intent.GetStringExtra("Agent Email");
            AgentMobile.Text = Intent.GetStringExtra("Agent Mobile");
            OfficeLocation.Text = Intent.GetStringExtra("Office Location");

            btn_Edit.Click += OnEdit_Click;
            btn_Delete.Click += OnDelete_Click;
        }

        public void OnEdit_Click(object sender, EventArgs e)
        {
            if (AgentName.Text != "" && AgentEmail.Text != "" && AgentMobile.Text != "" && OfficeLocation.Text != "")
            {

                DatabaseManager.EditProperty2(AgentName.Text, AgentEmail.Text, AgentMobile.Text, OfficeLocation.Text, AgentId);
                Toast.MakeText(this, "Agent data Updated", ToastLength.Long).Show();
                this.Finish();
                StartActivity(typeof(Home_Agent));
            }
            else
            {
                Toast.MakeText(this, "Please fill data in all fields", ToastLength.Long).Show();
            }
        }

        public void OnDelete_Click(object sender, EventArgs e)
        {
            DatabaseManager.DeleteProperty2(AgentId);
            Toast.MakeText(this, "Agent data is Deleted", ToastLength.Long).Show();
            this.Finish();
            StartActivity(typeof(Home_Agent));

        }
    }
}