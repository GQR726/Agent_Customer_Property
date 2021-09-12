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
    [Activity(Label = "EditUser")]
    public class EditUser : Activity
    {
        int Cust_Id;
        EditText Cust_Name;
        EditText Cust_Address;
        EditText Cust_Username;
        EditText Cust_Password;

        Button btn_Edit;
        Button btn_Delete;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            SetContentView(Resource.Layout.EditUserAccount);

            Cust_Name = FindViewById<EditText>(Resource.Id.txtEditLastName);
            Cust_Address = FindViewById<EditText>(Resource.Id.txtEditaAddress);
            Cust_Username = FindViewById<EditText>(Resource.Id.txtEditUsername);
            Cust_Password = FindViewById<EditText>(Resource.Id.txtEditPassword);

            btn_Edit = FindViewById<Button>(Resource.Id.btnEdit);
            btn_Delete = FindViewById<Button>(Resource.Id.btnDelete);
            
            Cust_Id = Intent.GetIntExtra("AgentId", -1); //-1 is default 
            Cust_Name.Text = Intent.GetStringExtra("Customer Name");
            Cust_Address.Text = Intent.GetStringExtra("Customer Address");
            Cust_Username.Text = Intent.GetStringExtra("Username");
            Cust_Password.Text = Intent.GetStringExtra("Password");

            btn_Edit.Click += Edit_Click;
            btn_Delete.Click += OnDelete_Click;
        }
        public void Edit_Click(object sender, EventArgs e)
        {
            if (Cust_Name.Text != "" && Cust_Address.Text != "" && Cust_Username.Text != "" && Cust_Password.Text != "")
            {

                DatabaseManager.EditProperty2(Cust_Name.Text, Cust_Address.Text, Cust_Username.Text, Cust_Password.Text, Cust_Id);
                Toast.MakeText(this, "Customer data Updated", ToastLength.Long).Show();
                this.Finish();
                StartActivity(typeof(login_home));
            }
            else
            {
                Toast.MakeText(this, "Please fill data in all fields", ToastLength.Long).Show();
            }
        }
        public void OnDelete_Click(object sender, EventArgs e)
        {
            DatabaseManager.DeleteProperty2(Cust_Id);
            Toast.MakeText(this, "Customer data is Deleted", ToastLength.Long).Show();
            this.Finish();
            StartActivity(typeof(Home_Agent));

        }
    }
}