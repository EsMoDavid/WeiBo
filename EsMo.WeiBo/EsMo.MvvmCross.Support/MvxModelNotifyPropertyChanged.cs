using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace EsMo.MvvmCross.Support
{
    public class MvxModelNotifyPropertyChanged<T>: MvxNotifyPropertyChanged where T:class
    {
        public T Model { get; private set; }
        public MvxModelNotifyPropertyChanged(T model)
        {
            this.Model = model;
        }
    }
}