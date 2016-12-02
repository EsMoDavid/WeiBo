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
using Android.Util;

namespace EsMo.Android.Support.Views
{
    public class WrappedLayout : ViewGroup
    {
        int colCount = 3;
        int itemSize = 0;
        public WrappedLayout(Context context):base(context)
        {
        }
       
        public WrappedLayout(Context context, IAttributeSet attrs):base(context,attrs)
        {

        }
        
        public WrappedLayout(Context context, IAttributeSet attrs, int defStyleAttr)
            :base( context,  attrs,  defStyleAttr)
        {

        }
        public WrappedLayout(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes)
            : base(context, attrs, defStyleAttr, defStyleRes)
        {

        }
        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            int layoutWidth = MeasureSpec.GetSize(widthMeasureSpec);
            int layoutHeight = MeasureSpec.GetSize(heightMeasureSpec);
            int count = this.ChildCount;
            int itemCount = 0;
            for (int i = 0; i < count; i++)
            {
                View view = this.GetChildAt(i);
                if (view.Visibility == ViewStates.Invisible || view.Visibility == ViewStates.Visible)
                {
                    itemCount++;
                }
            }
            itemSize = layoutWidth / colCount;
            int rowCount = itemCount % colCount == 0 ? itemCount / colCount : itemCount / colCount + 1;

            int resultWidth = layoutWidth;
            int resultHeight = rowCount* itemSize;
            this.SetMeasuredDimension(ResolveSize(resultWidth, widthMeasureSpec),
                ResolveSize(resultHeight, heightMeasureSpec));
        }
        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            if (changed)
            {
                int w = r - l;
                int childCount = this.ChildCount;
                int x = 0, y = 0;
                for (int i = 0; i < childCount; i++)
                {
                    View view = this.GetChildAt(i);
                    if (x + itemSize > w)
                    {
                        x = 0;
                        y += itemSize;
                    }
                    view.Layout(x, y, x + itemSize, y + itemSize);
                    System.Diagnostics.Debug.WriteLine(string.Format("{0} {1} {2} {3}", x, y, x + itemSize, y + itemSize));
                    x += itemSize;
                }
            }
        }
        protected override LayoutParams GenerateDefaultLayoutParams()
        {
            return new MarginLayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);
        }
        public override LayoutParams GenerateLayoutParams(IAttributeSet attrs)
        {
            return new MarginLayoutParams(this.Context, attrs);
        }
        protected override LayoutParams GenerateLayoutParams(LayoutParams p)
        {
            return new MarginLayoutParams(p);
        }
        protected override bool CheckLayoutParams(LayoutParams p)
        {
            return p is MarginLayoutParams;
        }
    }
}