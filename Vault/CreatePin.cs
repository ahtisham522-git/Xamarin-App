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

namespace Vault
{
    [Activity(Label = "CreatePin", Theme = "@style/AppTheme", MainLauncher = true)]
    public class CreatePin : Activity
    {
        Button btn;
        EditText psdet, psdet2;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your application here

            ISharedPreferences prefs = Application.Context.GetSharedPreferences("PASS_CODE", FileCreationMode.Private);
            string value2 = prefs.GetString("CPASS_WORD", null);

            if (value2 != null)
            {
                Intent i = new Intent(this, typeof(MainActivity));
                StartActivity(i);
                Finish();
            }
            SetContentView(Resource.Layout.createpin);



            
              

            //password feilds
            psdet = FindViewById<EditText>(Resource.Id.pedt1);
            psdet2 = FindViewById<EditText>(Resource.Id.pedt2);

            //Button handler 
            btn = FindViewById<Button>(Resource.Id.psetbtn);
            btn.Click += Intentclic;
        }
        private void Intentclic(object sender, EventArgs e)
        {

            string pas1 = psdet.Text.ToString();
            string pas2 = psdet2.Text.ToString();

            if(pas1==pas2)
            {

            ISharedPreferences prefs = Application.Context.GetSharedPreferences("PASS_CODE", FileCreationMode.Private);
            ISharedPreferencesEditor editor = prefs.Edit();
            editor.PutString("onetime", "done");
            editor.PutString("CPASS_WORD", pas1);
            editor.PutString("CPASS_WORD", pas2);
            editor.Apply();
            Intent i = new Intent(this, typeof(MainActivity));
            StartActivity(i);
                  }
            else
            {
                psdet.SetError("Password Not Matched", null);
                psdet.SetError(" Password Not Matched", null);
            }
        }
    }
}