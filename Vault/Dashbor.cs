using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Vault
{
    [Activity(Label = "dashbor")]
    public class Dashbor : Activity
    {

        Dialog dialog;

        Button confirm, cancel, add;
        EditText foldername;
        private RecyclerView folderRecycler;
        private Context folderContx;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Dashboard);

            add = FindViewById<Button>(Resource.Id.psetn);
            add.Click += popup;


            List<imageFolder> folders = Getfolders();
            
          if(folders!= null)
            {
                RecyclerView.Adapter folderAdapter = new FolderAdapter(folders,folderContx);
                folderRecycler.SetAdapter(folderAdapter);
                folderAdapter.NotifyDataSetChanged();

            }
        }
        private void popup(object sender, EventArgs e)
        {

            dialog = new Dialog(this);
            dialog.SetContentView(Resource.Layout.foldernamepop);
            dialog.Window.SetLayout(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
            dialog.SetCancelable(false);
            dialog.Window.SetSoftInputMode(SoftInput.AdjustResize);



            //dialog Buttons
            confirm = dialog.FindViewById<Button>(Resource.Id.okfname);
            cancel = dialog.FindViewById<Button>(Resource.Id.cancelfname);
            foldername = dialog.FindViewById<EditText>(Resource.Id.fnameedt);

            confirm.Click += confm;
            cancel.Click += cancl;
            dialog.Show();


        }


        private void cancl(object sender, EventArgs e)
        {

            dialog.Hide();


        }


        private void confm(object sender, EventArgs e)
        {
            string flder = foldername.Text.ToString();

            createDirectory(flder);
            //popup Confirm Button
            dialog.Hide();


        }

        private void createDirectory(string foldername)
        {
            string rootPath = Android.App.Application.Context.GetExternalFilesDir(null).ToString();

            var filePathDir = Path.Combine(rootPath, foldername);

            if (!File.Exists(filePathDir))
            {
                Directory.CreateDirectory(filePathDir);
            }
        }

        public List<imageFolder> Getfolders()
        {

            List<imageFolder> picFolders = new List<imageFolder>();
            string rootPath = Android.App.Application.Context.GetExternalFilesDir(null).ToString();
            List<String> picPaths = new List<String>();
            string[] files = Directory.GetDirectories(rootPath);
            //list of file to be counted
            for (int i = 0; i < files.Length; i++)
            {
                picPaths.Add(files[i]);
            }

            if (picPaths != null)
            {
                for (int s = 0; s < files.Length; s++)
                {
                    imageFolder folds = new imageFolder();
                    string foldername = Path.GetDirectoryName(files[s]);
                    folds.setFolderName(foldername);
                    picFolders.Add(folds);
                }
            }

            return picFolders;
        }

    }
}
    

