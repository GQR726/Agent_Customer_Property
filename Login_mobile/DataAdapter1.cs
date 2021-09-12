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
    class DataAdapter1 : BaseAdapter<Property>
    {
        private readonly Activity context;
        private readonly List<Property> items;
        public DataAdapter1(Activity context, List<Property> items)
        {
            this.context = context;
            this.items = items;
        }
        public override Property this[int position]
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
                view = context.LayoutInflater.Inflate(Resource.Layout.Property_Inform, null);
            view.FindViewById<TextView>(Resource.Id.houseName).Text = item.Property_Name;
            view.FindViewById<TextView>(Resource.Id.houseRent).Text = item.Property_WeeklyRent;
            view.FindViewById<TextView>(Resource.Id.houseDetails).Text = item.Property_Location;
            return view;
        }
    }
}