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
using Android.Graphics.Drawables;
using Android.Util;

namespace EsMo.Android.Support.Utils
{
    public static class UIUtils
    {
        static ProgressDialog progressDialog;
        public static void ShowProgressDialog(string content, Context context)
        {
            if (progressDialog == null)
            {
                progressDialog = new ProgressDialog(context);
                progressDialog.Indeterminate = true;
                progressDialog.Show();
            }
            progressDialog.SetMessage(content);
        }
        public static void CloseProgressDialog()
        {
            if (progressDialog != null)
            {
                progressDialog.Hide();
                progressDialog.Dismiss();
                progressDialog = null;
            }
        }
    }
   
}