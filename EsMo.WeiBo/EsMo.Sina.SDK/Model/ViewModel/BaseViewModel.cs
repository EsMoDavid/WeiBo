using EsMo.Sina.SDK.Resource;
using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsMo.Sina.SDK.Model
{
    public abstract class BaseViewModel: MvxViewModel
    {
        public virtual void Appearing()
        {

        }

        string title;

        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                if (title != value)
                {
                    title = value;
                    this.RaisePropertyChanged(() => this.Title);
                }
            }
        }
    }
}
