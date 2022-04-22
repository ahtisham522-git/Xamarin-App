using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;

namespace Vault
{
    [Activity(Label = "@string/app_name")]
    public class MainActivity : AppCompatActivity
    {
        EditText pincode;
        Button confim;
        protected override void OnCreate(Bundle savedInstanceState)
        {
           
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            pincode = FindViewById<EditText>(Resource.Id.edt1);

            confim = FindViewById<Button>(Resource.Id.confrm);

            confim.Click += Intentclick;
        }
        private void Intentclick(object sender, EventArgs e)
        {
            ISharedPreferences prefs = Application.Context.GetSharedPreferences("PASS_CODE", FileCreationMode.Private);

            string pas1 = pincode.Text.ToString();
            string value2 = prefs.GetString("CPASS_WORD", null);

            if(pas1==value2)
            {
                Intent i = new Intent(this, typeof(Dashbor));
                StartActivity(i);
                Finish();
            }
            else
            {
                pincode.SetError("Wrong Password", null);
            }

        }



    }
}