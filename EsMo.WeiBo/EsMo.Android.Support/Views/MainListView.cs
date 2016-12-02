using System;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Util;

using Android.Support.V7.Widget;

namespace EsMo.Android.Support.Views
{
    public class LoadableListView : ListView, AbsListView.IOnScrollListener
    {
        //View footer;
        //ProgressBar progLoading;
        //TextView tvLoading;
        bool isLoading = false;
        int firstVisibleItem, visibleItemCount, totalItemCount;
        public bool IsLoading
        {
            get
            {
                return isLoading;
            }

            private set
            {
                isLoading = value;
                //this.SwitchLoadingBar(value);
            }
        }

        public event EventHandler OnBottomLoading;
        public void FinishLoading()
        {
            this.IsLoading = false;
            Log.Debug("d", "isLoading = false");
        }
        public LoadableListView(Context context) : base(context)
        {
            this.Init();
        }
        public LoadableListView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            this.Init();
        }
        public LoadableListView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
            this.Init();
        }
        public LoadableListView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
        {
            this.Init();
        }
        void Init()
        {
            this.SetOnScrollListener(this);
            //this.footer = View.Inflate(this.Context, Resource.Layout.FooterLoading, null);
            //this.progLoading = this.footer.FindViewById<ProgressBar>(Resource.Id.progloading);
            //this.tvLoading = this.footer.FindViewById<TextView>(Resource.Id.textView1);
            //this.AddFooterView(this.footer);
        }
        
        public void OnScroll(AbsListView view, int firstVisibleItem, int visibleItemCount, int totalItemCount)
        {
            //throw new NotImplementedException();
            Log.Debug("firstVisibleItem", firstVisibleItem.ToString());
            Log.Debug("visibleItemCount", visibleItemCount.ToString());
            Log.Debug("totalItemCount", totalItemCount.ToString());
            this.firstVisibleItem = firstVisibleItem;
            this.visibleItemCount = visibleItemCount;
            this.totalItemCount = totalItemCount;
        }
        private void SwitchLoadingBar(bool isLoading)
        {
            //if(isLoading)
            //{
            //    this.progLoading.Visibility = ViewStates.Visible;
            //    this.tvLoading.Visibility = ViewStates.Visible;
            //}
            //else
            //{
            //    this.progLoading.Visibility = ViewStates.Gone;
            //    this.tvLoading.Visibility = ViewStates.Gone;
            //}
        }
        public void OnScrollStateChanged(AbsListView view, [GeneratedEnum] ScrollState scrollState)
        {
            if (scrollState == ScrollState.Idle){
                if(this.firstVisibleItem+this.visibleItemCount>=this.totalItemCount &&!IsLoading)
                {
                    this.IsLoading = true;
                    System.Diagnostics.Debug.WriteLine("bottom");
                    if (this.OnBottomLoading != null)
                    {
                        if (this.OnBottomLoading != null)
                            this.OnBottomLoading(this, EventArgs.Empty);
                    }
                }
            }
        }
    }
}