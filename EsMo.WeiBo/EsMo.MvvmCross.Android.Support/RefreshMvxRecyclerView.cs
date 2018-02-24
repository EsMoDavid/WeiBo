using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Support.V7.RecyclerView;

namespace EsMo.MvvmCross.Android.Support
{
    public class RefreshMvxRecyclerView : MvxRecyclerView
    {
        int lastVisibleItem;
        LinearLayoutManager linearLayoutManager;
        public event EventHandler OnBottomRefreshing;
        public RefreshMvxRecyclerView(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
            this.Init();
        }

        public RefreshMvxRecyclerView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            this.Init();
        }

        public RefreshMvxRecyclerView(Context context, IAttributeSet attrs, int defStyle) : base(context, attrs, defStyle)
        {
            this.Init();
        }

        public RefreshMvxRecyclerView(Context context, IAttributeSet attrs, int defStyle, IMvxRecyclerAdapter adapter) : base(context, attrs, defStyle, adapter)
        {
            this.Init();
        }
        void Init()
        {
            this.linearLayoutManager = new LinearLayoutManager(Context);
            this.SetLayoutManager(this.linearLayoutManager);
            this.HasFixedSize = true;
        }
        public override void OnScrolled(int dx, int dy)
        {
            base.OnScrolled(dx, dy);
            this.lastVisibleItem = this.linearLayoutManager.FindLastVisibleItemPosition();
        }
        public override void OnScrollStateChanged(int state)
        {
            base.OnScrollStateChanged(state);
            if (state == RecyclerView.ScrollStateIdle && this.lastVisibleItem + 1 == this.GetAdapter().ItemCount)
            {
                this.InvokebottomRefreshing();
            }
        }

        void InvokebottomRefreshing()
        {
            if (this.OnBottomRefreshing != null)
                this.OnBottomRefreshing(this, EventArgs.Empty);
        }
    }
}