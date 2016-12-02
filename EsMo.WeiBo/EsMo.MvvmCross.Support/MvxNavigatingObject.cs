using MvvmCross.Core.ViewModels;

namespace EsMo.MvvmCross.Support
{
    public abstract class MvxNavigatingObject<T>: MvxNavigatingObject where T:class
    {
        public T Model { get; private set; }
        public MvxNavigatingObject(T model)
        {
            this.Model = model;
        }
    }
}
