using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Login_mobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Login_mobile
{
    [Activity(Label = "Home_Property")]
    public class Home_Property : Activity
    {
        ListView PropertyList;
        List<Property> myList1 = new List<Property>();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.DisplayList1);

            PropertyList = FindViewById<ListView>(Resource.Id.listView1);
            myList1 = DatabaseManager.GetPropertyData();
            PropertyList.Adapter = new DataAdapter1(this, myList1);
            PropertyList.ItemClick += OnProperty_ListClick;
        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            menu.Add("Add Property");
            return base.OnPrepareOptionsMenu(menu);
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            var itemTitle = item.TitleFormatted.ToString();

            switch (itemTitle)
            {
                case "Add Property":
                    StartActivity(typeof(AddProperty_Activity));
                    break;
            }
            return base.OnOptionsItemSelected(item);
        }
        void OnProperty_ListClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var Property_Item = myList1[e.Position];

            var Edit_Property_item = new Intent(this, typeof(EditProperty_Activity));
            Edit_Property_item.PutExtra("Property_Name", Property_Item.Property_Name);
            Edit_Property_item.PutExtra("Property_WeeklyRent", Property_Item.Property_WeeklyRent);
            Edit_Property_item.PutExtra("Property_Location", Property_Item.Property_Location);
            Edit_Property_item.PutExtra("PropertyId", Property_Item.Id);
            //Toast.MakeText(this, Tutor_Item.Id.ToString(), ToastLength.Long).Show();
            StartActivity(Edit_Property_item);
        }
    }
}