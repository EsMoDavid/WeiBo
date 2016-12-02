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
using Android.Util;

namespace EsMo.Android.Support.Views
{
    public class RefreshRecyclerView : RecyclerView
    {
        int lastVisibleItem;
        LinearLayoutManager linearLayoutManager;
        public event EventHandler OnBottomRefreshing;
        public RefreshRecyclerView(Context context) : base(context)
        {
            this.Init();
        }
        public RefreshRecyclerView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            this.Init();
        }
        public RefreshRecyclerView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
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
            if(state == RecyclerView.ScrollStateIdle && this.lastVisibleItem+1==this.GetAdapter().ItemCount)
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