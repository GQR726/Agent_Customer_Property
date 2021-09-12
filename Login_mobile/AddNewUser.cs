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
    [Activity(Label = "AddNewUser")]
    public class AddNewUser : Activity
    {
        EditText Cust_Name;
        EditText Cust_Address;
        EditText Cust_Username;
        EditText Cust_Password;
        Button btn_Account;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.AddUserAccount);

            Cust_Name = FindViewById<EditText>(Resource.Id.txtEditLastName);
            Cust_Address = FindViewById<EditText>(Resource.Id.txtEditaAddress);
            Cust_Username = FindViewById<EditText>(Resource.Id.txtEditUsername);
            Cust_Password = FindViewById<EditText>(Resource.Id.txtEditPassword);
            btn_Account = FindViewById<Button>(Resource.Id.btnAdd);
            btn_Account.Click += User_Add;
        }
        private void User_Add(object sender, EventArgs e)
        {
            if (Cust_Name.Text != "" && Cust_Address.Text != "" && Cust_Username.Text != "" && Cust_Password.Text != "")
            {
                DatabaseManager.AddAgent(Cust_Name.Text, Cust_Address.Text, Cust_Username.Text, Cust_Password.Text);
                Toast.MakeText(this, "New Agent data Added", ToastLength.Long).Show();
                this.Finish();
                StartActivity(typeof(MainActivity));
            }
            else
            {
                Toast.MakeText(this, "Please fill data in all fields", ToastLength.Long).Show();
            }
        }
    }
}