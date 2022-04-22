using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
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

        Button confirm, cancel,add;
        EditText foldername;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Dashboard);

           add = FindViewById<Button>(Resource.Id.psetn);
           add.Click += popup;
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



        private ArrayList<imageFolder> GetPicturePaths()
        {

            List<imageFolder> picFolders = new List<imageFolder>();

            string rootPath = Android.App.Application.Context.GetExternalFilesDir(null).ToString();
                List<String> picPaths = new List<String>();

                List<int> filecount = new List<int>();

           Java.IO.File myDir = new Java.IO.File(rootPath);

              
                String folder = myDir.Name;
            String folderq = myDir.AbsolutePath;

            //list of file to be counted

            myDir.ListFiles();
            
                for (File inFile : myDir) {
                if (inFile.isDirectory())
                {
                    fldernames.add(inFile.getName());
                    picPaths.add(inFile.getPath());
                    filecount.add(inFile.listFiles().length);
                }
            }
            if (picPaths != null)
            {
                for (int s = 0; s < fldernames.size(); s++)
                {
                    imageFolder folds = new imageFolder();
                    String foldername = fldernames.get(s);
                    String folderpaths = picPaths.get(s);
                    int numofpc = filecount.get(s);
                    folds.setPath(folderpaths);
                    folds.setFolderName(foldername);
                    folds.setNumberOfPics(numofpc);
                    picFolders.add(folds);

                    //   folds.setFirstPic(datapath);//if the folder has only one picture this line helps to set it as first so as to avoid blank image in itemview
                    //  folds.addpics();
                }
            }
            return picFolders;
        }

    }
}
