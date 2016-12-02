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
using System.IO;

namespace EsMo.Android.Support.Async
{
    public abstract class  BaseAsyncTask<TParams,TResult> : AsyncTask<TParams, int, TResult>
    {
        Action<TParams[], TResult> onFinished;
        protected TParams[] p;
        protected override void OnPreExecute()
        {
            Process.SetThreadPriority(ThreadPriority.Background);
        }
        public BaseAsyncTask(Action<TParams[],TResult> onFinished)
        {
            this.onFinished = onFinished;
        }
       
        protected override void OnPostExecute(TResult result)
        {
            if (this.IsCancelled) return;
            if(onFinished != null)
                this.onFinished(p,result);
        }
    }
}