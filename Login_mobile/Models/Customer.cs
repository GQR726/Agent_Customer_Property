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

namespace Login_mobile.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Cust_Name { get; set; }
        public string Cust_Address { get; set; }
        public string Cust_Username { get; set; }
        public string Cust_Password { get; set; }

    }
}