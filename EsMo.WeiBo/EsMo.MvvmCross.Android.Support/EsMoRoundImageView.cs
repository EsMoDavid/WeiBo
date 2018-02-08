using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using MvvmCross.Binding.Droid.Views;

namespace EsMo.MvvmCross.Android.Support
{
    [Register("EsMo.MvvmCross.Android.Support.EsMoRoundImageView")]
    public class EsMoRoundImageView : MvxImageView
    {
        private int DEFAULT_BORDER_WIDTH = 0;
        private Color DEFAULT_BORDER_COLOR = Color.Transparent;
        private Color DEFAULT_FILL_COLOR = Color.Transparent;
        private bool roundDisable;
        private RoundMode roundMode = RoundMode.ROUND_DRAWABLE;
        private Color borderColor = Color.Transparent;
        private int borderWidth = Color.Transparent;
        private Color fillColor = Color.Transparent;

        private Paint borderPaint;
        private Paint fillPaint;
        private Paint imagePaint;
        private Paint portPaint;

        private Rect bounds = new Rect();
        private float radius = 0;
        private float cx = 0;
        private float cy = 0;
        public EsMoRoundImageView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
        {
            this.Init();
        }
        public EsMoRoundImageView(Context context) : base(context)
        {
            this.Init();
        }

        public EsMoRoundImageView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            this.Init();
        }

        public EsMoRoundImageView(Context context, IAttributeSet attrs, int defStyle) : base(context, attrs, defStyle)
        {
            this.Init();
        }
        protected EsMoRoundImageView(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
            this.Init();
        }
        void Init()
        {
            portPaint = new Paint();
            portPaint.AntiAlias = true;

            borderPaint = new Paint();
            borderPaint.AntiAlias = true;
            borderPaint.Color = DEFAULT_BORDER_COLOR;
            borderPaint.StrokeWidth = DEFAULT_BORDER_WIDTH;
            borderPaint.SetStyle(Paint.Style.Stroke);

            fillPaint = new Paint();
            fillPaint.AntiAlias = true;
            fillPaint.Color = DEFAULT_FILL_COLOR;
            fillPaint.SetStyle(Paint.Style.Fill);

            imagePaint = new Paint();
            imagePaint.AntiAlias = true;
            imagePaint.SetXfermode(new PorterDuffXfermode(PorterDuff.Mode.SrcIn));
        }
        public RoundMode RoundMode
        {
            set
            {
                if (this.roundMode != value)
                {
                    this.roundMode = value;
                    this.Invalidate();
                }
            }
            get
            {
                return this.roundMode;
            }
        }
        public bool RoundDisable
        {
            get
            {
                return this.roundDisable;
            }
        }
        public Color BorderColor
        {
            get
            {
                return this.borderColor;
            }
            set
            {
                if (this.borderColor != value)
                {
                    this.borderColor = value;
                    borderPaint.Color = value;
                }
            }
        }
        public int BorderWidth
        {
            get
            {
                return this.borderWidth;
            }
            set
            {
                if (this.borderWidth != value)
                {
                    this.borderWidth = value;
                    borderPaint.StrokeWidth = value;
                    this.Invalidate();
                }
            }
        }
        public Color FillColor
        {
            get
            {
                return this.fillColor;
            }
            set
            {
                if (this.fillColor != value)
                {
                    this.fillColor = value;
                    this.fillPaint.Color = value;
                }
            }
        }
        protected override void OnDraw(Canvas canvas)
        {
            if (this.roundDisable)
            {
                base.OnDraw(canvas);
                return;
            }
            if(this.Drawable==null && this.RoundMode == RoundMode.ROUND_DRAWABLE)
            {
                base.OnDraw(canvas);
                return;
            }
            this.ComputeRoundBounds();
            this.DrawCircle(canvas);
            this.DrawImage(canvas);

        }
        private void DrawImage(Canvas canvas)
        {
            Bitmap src = Bitmap.CreateBitmap(this.Width, this.Height, Bitmap.Config.Argb4444);
            base.OnDraw(new Canvas(src));
            Bitmap port = Bitmap.CreateBitmap(this.Width, this.Height, Bitmap.Config.Argb4444);
            Canvas portCanvas = new Canvas(port);
            int saveCount = portCanvas.SaveCount;
            portCanvas.Save();
            this.AdjustCanvas(portCanvas);
            portCanvas.DrawCircle(cx, cy, radius, portPaint);
            portCanvas.RestoreToCount(saveCount);
            portCanvas.DrawBitmap(src, 0, 0, imagePaint);
            src.Recycle();
            canvas.DrawBitmap(port, 0, 0, null);
            port.Recycle();
        }
        private void DrawCircle(Canvas canvas)
        {
            int saveCount = canvas.SaveCount;
            canvas.Save();
            this.AdjustCanvas(canvas);
            canvas.DrawCircle(cx, cy, radius, fillPaint);
            if (borderWidth > 0)
            {
                canvas.DrawCircle(cx, cy, radius - borderWidth / 2f, borderPaint);
            }
            canvas.RestoreToCount(saveCount);
        }
        private void ComputeRoundBounds()
        {
            if (this.RoundMode == RoundMode.ROUND_VIEW)
            {
                bounds.Left = this.PaddingLeft;
                bounds.Top = this.PaddingTop;
                bounds.Right = this.Width - this.PaddingRight;
                bounds.Bottom = this.Height - this.PaddingBottom;
            }
            else if (this.RoundMode == RoundMode.ROUND_DRAWABLE)
            {
                this.Drawable.CopyBounds(bounds);
            }
            this.radius = Math.Min(bounds.Width(), bounds.Height()) / 2f;
            cx = bounds.Left + bounds.Width() / 2f;
            cy = bounds.Top + bounds.Height() / 2f;
        }
        private void AdjustCanvas(Canvas canvas)
        {
            if (this.RoundMode == RoundMode.ROUND_DRAWABLE)
            {
                if (Build.VERSION.SdkInt >= BuildVersionCodes.JellyBean)
                {
                    if (this.CropToPadding)
                    {
                        int scrollX = this.ScrollX;
                        int scrollY = this.ScrollY;
                        canvas.ClipRect(scrollX + this.PaddingLeft, scrollY + this.PaddingTop,
                            scrollX + this.Right - this.Left - this.PaddingRight,
                            scrollY + this.Bottom - this.Top - this.PaddingBottom);
                    }
                }
                canvas.Translate(this.PaddingLeft, this.PaddingTop);
                if (this.ImageMatrix != null)
                {
                    Matrix m = new Matrix(this.ImageMatrix);
                    canvas.Concat(m);
                }
            }
        }
    }
    public enum RoundMode
    {
        ROUND_VIEW,
        ROUND_DRAWABLE
    }

}