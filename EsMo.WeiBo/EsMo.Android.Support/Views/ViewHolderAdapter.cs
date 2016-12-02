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
    /// <summary>
    /// Customized array adapter
    /// </summary>
    /// <typeparam name="T">Item type</typeparam>
    /// <typeparam name="Holder">View holder type</typeparam>
    public abstract class ViewHolderAdapter<T, Holder> : BaseAdapter<T>
           where Holder : BaseHolder<T>, new()
    {
        public Context Context { get; private set; }
        IList<T> listItems;
        public ViewHolderAdapter(Context context, IList<T> listItems)
        {
            this.Context = context;
            this.listItems = listItems;
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;
            Holder item;
            T t = this[position];

            if (view == null)
            {
                item = new Holder();
                view = item.OnGetView(this.Context);
                view.Tag = item;
            }
            else
                item = view.Tag as Holder;
            item.UpdateView(t);
            return view;
        }
        public override T this[int position]
        {
            get
            {
                return this.listItems[position];
            }
        }
        public override int Count
        {
            get
            {
                return this.listItems.Count;
            }
        }
        public override long GetItemId(int position)
        {
            return position;
        }
    }
    public abstract class RefreshHolderAdapter<Model, Holder> : RecyclerView.Adapter
          where Holder :BaseRecyclerHolder<Model>
    {
        const int TypeItem = 0;
        const int TypeFooter = 1;
        IList<Model> listItems;
        int resourceID;
        Func<View, Holder> createHolder;
        public FooterViewHolder FooterHolder { get; private set; }
        public event EventHandler<ItemClickEventArgs> OnItemClick;
        public RefreshHolderAdapter(IList<Model> listItems,Func<View,Holder> createHolder, int resourceID=0) : base()
        {
            this.listItems = listItems;
            this.resourceID = resourceID;
            this.createHolder = createHolder;
        }
        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            if (holder is FooterViewHolder) return;
            Holder h = holder as Holder;
            h.UpdateView(this[position]);
        }
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            int resID = viewType == TypeFooter ? this.FooterLayouteID : this.resourceID;
           
            View view = LayoutInflater.From(parent.Context).Inflate(resID, parent, false);
            if (viewType != TypeFooter)
            {
                Holder holder = this.createHolder(view);
                holder.OnHolderClick += Holder_OnHolderClick;
                return holder;
            }
            else
            {
                this.FooterHolder = new FooterViewHolder(view);
                return this.FooterHolder;
            }
        }

        private void Holder_OnHolderClick(object sender, EventArgs e)
        {
            Holder holder = sender as Holder;
            if(this.OnItemClick!=null)
            {
                this.OnItemClick(sender, new ItemClickEventArgs() { ItemIndex = holder.AdapterPosition });
            }
        }

        public virtual Model this[int i]
        {
            get
            {
                return this.listItems[i];
            }
        }
        public int FooterLayouteID { get; set; }
        public override int GetItemViewType(int position)
        {
            if (position == this.ItemCount - 1 && this.FooterLayouteID!=0)
                return TypeFooter;
            return base.GetItemViewType(position);
        }
        public override int ItemCount
        {
            get
            {
                int footer = this.FooterLayouteID == 0 ? 0 : 1;
                return this.listItems.Count + footer;
            }
        }
    
        public class FooterViewHolder : RecyclerView.ViewHolder
        {
            public FooterViewHolder(View footerView) : base(footerView)
            {

            }
        }
    }
}