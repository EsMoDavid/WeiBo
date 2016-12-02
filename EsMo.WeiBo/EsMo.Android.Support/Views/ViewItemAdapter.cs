using Android.Content;
using Android.Views;
using EsMo.Core;
using System;
using System.Collections.Generic;


namespace EsMo.Android.Support.Views
{
    public abstract class ViewItemAdapter<VModel, Model, Holder> : ViewHolderAdapter<VModel, Holder>
        where VModel : IModelOwner<Model>, new()
        where Holder : BaseHolder<VModel>, new()
    {
        IList<Model> listItems;
        public ViewItemAdapter(Context context, IList<Model> listItems) : base(context, null)
        {
            this.listItems = listItems;
        }
        public override VModel this[int position]
        {
            get
            {
                VModel t = new VModel();
                t.SetModel(listItems[position]);
                return t;
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
    public class RefreshVItemAdapter<VModel, Model, Holder> : RefreshHolderAdapter<VModel, Holder>
        where VModel : IModelOwner<Model>, new()
        where Holder : BaseRecyclerHolder<VModel>
    {
        IList<Model> listItems;
        public RefreshVItemAdapter(IList<Model> listItems, Func<View, Holder> createHolder, int resourceID = -1) : base(null, createHolder, resourceID)
        {
            this.listItems = listItems;
        }
        public override VModel this[int i]
        {
            get
            {
                VModel vModel = new VModel();
                vModel.SetModel(this.listItems[i]);
                return vModel;
            }
        }
        public override int ItemCount
        {
            get
            {
                int footer = this.FooterLayouteID == 0 ? 0 : 1;
                return this.listItems.Count + footer;
            }
        }
    }
}