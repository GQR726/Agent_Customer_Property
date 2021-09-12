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
    class DataAdapter2 : BaseAdapter<Agent>
    {
        private readonly Activity context;
        private readonly List<Agent> items;
        public DataAdapter2(Activity context, List<Agent> items)
        {
            this.context = context;
            this.items = items;
        }
        public override Agent this[int position]
        {
            get { return items[position]; }
        }

        public override int Count
        {
            get
            {
                return items.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];
            var view = convertView;
            if (view == null) // no view to re-use, create new
                view = context.LayoutInflater.Inflate(Resource.Layout.Agent_Inform, null);
            view.FindViewById<TextView>(Resource.Id.agentName).Text = item.Agent_Name;
            view.FindViewById<TextView>(Resource.Id.agentEmail).Text = item.Agent_Email;
            view.FindViewById<TextView>(Resource.Id.agentMobile).Text = item.Agent_Mobile;
            return view;
        }
    }
}