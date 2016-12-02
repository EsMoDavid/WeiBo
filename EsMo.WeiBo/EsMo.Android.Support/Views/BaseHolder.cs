using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;

namespace EsMo.Android.Support.Views
{
    public abstract class BaseHolder<T>:Java.Lang.Object
    {
        public abstract View OnGetView(Context context);
        public abstract void UpdateView(T viewModel);   
    }
    public abstract class BaseRecyclerHolder<T>: RecyclerView.ViewHolder
    {
        public event EventHandler OnHolderClick;
        public BaseRecyclerHolder(View itemView):base(itemView)
        {
            itemView.Click += ItemView_Click;
        }

        private void ItemView_Click(object sender, EventArgs e)
        {
            if (this.OnHolderClick != null)
                this.OnHolderClick(this, e);
        }

        public abstract void UpdateView(T viewModel);
        
    }
}