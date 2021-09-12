using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;

namespace Login_mobile
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        EditText UserName;
        EditText Email;
        EditText Password;
        Button btn_Login;
        Button btn_Sign;
        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            UserName = FindViewById<EditText>(Resource.Id.txtUserName);
            Email = FindViewById<EditText>(Resource.Id.txtEmail);
            Password = FindViewById<EditText>(Resource.Id.txtPassword);
            btn_Login = FindViewById<Button>(Resource.Id.btn1);
            btn_Sign = FindViewById<Button>(Resource.Id.btn2);

            btn_Login.Click += Login_Fun;
            btn_Sign.Click += Add_Fun;
        }

        private void Login_Fun(object sender, EventArgs e)
        {
            if (UserName.Text == "1" && Password.Text == "1")
            {
                Toast.MakeText(this, "Login successfully done!", ToastLength.Long).Show();
                StartActivity(typeof(login_home));
            }
            else
            {
                //Toast.makeText(getActivity(), "Wrong credentials found!", Toast.LENGTH_LONG).show();  
                Toast.MakeText(this, "Wrong credentials found!", ToastLength.Long).Show();
            }
        }
        private void Add_Fun(object sender, EventArgs e)
        {
            StartActivity(typeof(AddNewUser));
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}