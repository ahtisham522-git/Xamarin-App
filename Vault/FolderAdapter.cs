using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vault
{
    class FolderAdapter : RecyclerView.Adapter
    {
        public List<imageFolder> folds;
        public Context contx;

        public FolderAdapter(List<imageFolder> folders, Context folderContx)
            //, itemClickListener listen)
        {
           this.folds = folders;
           contx = folderContx;

          //  this.listenToClick = listen;
        }


        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {

            FviewHolder vh = holder as FviewHolder;

          //  imageFolder folder = folds(position)

           // String text = "" + folder.getFolderName();
           // String folderSizeString = "" + folder.getNumberOfPics() + " Images";
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {


            LayoutInflater inflater = LayoutInflater.From(parent.Context);
            View cell = inflater.Inflate(Resource.Layout.folders, parent, false);

            RecyclerView.ViewHolder vh = new FviewHolder(cell);
            return vh;
        }

        private class FviewHolder : RecyclerView.ViewHolder
        {
            public TextView name{ get; private set; }
            public TextView size { get; private set; }


            ImageView image { get; }
            ImageView tick { get; }

            public FviewHolder(View itemView) : base(itemView)
            {
                name = itemView.FindViewById<TextView>(Resource.Id.folderName);
                size = itemView.FindViewById<TextView>(Resource.Id.folderSize);

                image = itemView.FindViewById<ImageView>(Resource.Id.folderPic);
                tick = itemView.FindViewById<ImageView>(Resource.Id.iv_checkbox);

            }
        }

        public override int ItemCount => throw new NotImplementedException();
    }
}
