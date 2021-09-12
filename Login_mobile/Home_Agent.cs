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
    [Activity(Label = "Home_Agent")]
    public class Home_Agent : Activity
    {
        ListView AgentList;
        List<Agent> myList2 = new List<Agent>();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.DisplayList2);

            AgentList = FindViewById<ListView>(Resource.Id.listView2);
            myList2 = DatabaseManager.GetAgentData();
            AgentList.Adapter = new DataAdapter2(this, myList2);
            AgentList.ItemClick += OnAgent_ListClick;
        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            menu.Add("Add Agent");
            return base.OnPrepareOptionsMenu(menu);
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            var itemTitle = item.TitleFormatted.ToString();

            switch (itemTitle)
            {
                case "Add Agent":
                    StartActivity(typeof(AddAgent_Activity));
                    break;
            }
            return base.OnOptionsItemSelected(item);
        }
        void OnAgent_ListClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var Property_Item = myList2[e.Position];

            var Edit_Agent_item = new Intent(this, typeof(EditAgent_Activity));
            Edit_Agent_item.PutExtra("Agent_Name", Property_Item.Agent_Name);
            Edit_Agent_item.PutExtra("Agent_Email", Property_Item.Agent_Email);
            Edit_Agent_item.PutExtra("Agent_Mobile", Property_Item.Agent_Mobile);
            Edit_Agent_item.PutExtra("AgentId", Property_Item.Id);
            //Toast.MakeText(this, Tutor_Item.Id.ToString(), ToastLength.Long).Show();
            StartActivity(Edit_Agent_item);
        }
    }
}