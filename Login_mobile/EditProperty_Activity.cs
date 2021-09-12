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
    [Activity(Label = "EditProperty_Activity")]
    public class EditProperty_Activity : Activity
    {
        int PropertyId;
        TextView weeklyrent;
        TextView numberofbedrooms;
        TextView numberofbathrooms;
        TextView PropertyLocation;

        Button btn_Edit;
        Button btn_Delete;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.EditProperty);

            weeklyrent = FindViewById<TextView>(Resource.Id.weeklyrent);
            numberofbedrooms = FindViewById<TextView>(Resource.Id.numberofbedrooms);
            numberofbathrooms = FindViewById<TextView>(Resource.Id.numberofbathrooms);
            PropertyLocation = FindViewById<TextView>(Resource.Id.PropertyLocation);

            btn_Edit = FindViewById<Button>(Resource.Id.btnEdit);
            btn_Delete = FindViewById<Button>(Resource.Id.btnDelete);

            PropertyId = Intent.GetIntExtra("PropertyId", -1); //-1 is default 
            weeklyrent.Text = Intent.GetStringExtra("weekly rent");
            numberofbedrooms.Text = Intent.GetStringExtra("number of bedrooms");
            numberofbathrooms.Text = Intent.GetStringExtra("number of bathrooms");
            PropertyLocation.Text = Intent.GetStringExtra("Property Location");

            btn_Edit.Click += OnEdit_Click;
            btn_Delete.Click += OnDelete_Click;
        }

        public void OnEdit_Click(object sender, EventArgs e)
        {
            if (weeklyrent.Text != "" && numberofbedrooms.Text != "" && numberofbathrooms.Text != "" && PropertyLocation.Text != "")
            {

                DatabaseManager.EditProperty1(weeklyrent.Text, numberofbedrooms.Text, numberofbathrooms.Text, PropertyLocation.Text, PropertyId);
                Toast.MakeText(this, "Property data Updated", ToastLength.Long).Show();
                this.Finish();
                StartActivity(typeof(Home_Property));
            }
            else
            {
                Toast.MakeText(this, "Please fill data in all fields", ToastLength.Long).Show();
            }
        }

        public void OnDelete_Click(object sender, EventArgs e)
        {
            DatabaseManager.DeleteProperty1(PropertyId);
            Toast.MakeText(this, "Property data is Deleted", ToastLength.Long).Show();
            this.Finish();
            StartActivity(typeof(Home_Property));

        }
    }
}