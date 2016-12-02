using EsMo.MvvmCross.Support;
using EsMo.Sina.Model;
using EsMo.Sina.Model.Groups;
using System.Diagnostics;

namespace EsMo.Sina.SDK.Model
{
    public class CommentItemViewModel : MvxModelNotifyPropertyChanged<Comment>
    {
        public CommentItemViewModel ReplyComment { get; private set; }

        public CommentItemViewModel(Comment model) : base(model)
        {
            if (HasReplyComment)
            {
                this.ReplyComment = new CommentItemViewModel(model.ReplyComment);
            }
        }
        public string ProfileUrl
        {
            get
            {
                return this.Model.User.ActualProfileUrl;
            }
        }
        public string Name
        {
            get
            {
                return this.Model.User.ActualGeneralName;
            }
        }
        public string Content
        {
            get
            {
                Debug.WriteLine(this.Model.Text);
                return this.Model.Text;
            }
        }
        public string Desc
        {
            get
            {
                return this.Model.CreatedAt.DateConvertToString();
            }
        }
        public bool HasReplyComment
        {
            get
            {
                return this.ReplyComment != null;
            }
        }
    }
}
