using EsMo.MvvmCross.iOS.Support.Converter;
using EsMo.Sina.SDK.Model;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using System;

namespace EsMo.iOS.WeiBo.Entity
{
    public partial class MenuItemCell : MvxTableViewCell
    {

        public static readonly NSString Key = new NSString("MenuItemCell");

        public MenuItemCell (IntPtr handle) : base (handle)
        {
        }
        public MenuItemCell():base()
        {

        }
        public override void AwakeFromNib()
        {
            base.AwakeFromNib();
            
            this.DelayBind(() =>
            {
                var set = this.CreateBindingSet<MenuItemCell, MenuItemViewModel>();
                set.Bind(this.imgIcon).To(vm => vm.Icon).WithConversion(Converter.StreamToUIImage);
                set.Bind(this.txtTitle).To(vm => vm.Text);
                set.Bind(this).For(x => x.Hidden).To("Text==null");
                // The following have no support on MvvmCross
                //http://stackoverflow.com/questions/30530656/binding-in-code-to-property-with-operation-without-special-valueconverter
                //set.Bind(this).For(x => x.Hidden).To(vm => !string.IsNullOrEmpty(vm.Text));
                set.Apply();
            });
        }
    }
}