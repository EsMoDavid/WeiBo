using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MvvmCross.iOS.Views.Presenters;
using UIKit;

namespace EsMo.iOS.WeiBo
{
    public class MainViewPresenter: MvxIosViewPresenter
    {
        UIWindow window;
        public MainViewPresenter(IUIApplicationDelegate applicationDelegate, UIWindow window)
            :base(applicationDelegate,window)
        {
            this.window = window;
        }
    }
}