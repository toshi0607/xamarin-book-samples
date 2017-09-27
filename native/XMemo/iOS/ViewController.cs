using System;

using UIKit;

namespace XMemo.iOS
{
    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            MemoHolder.Current.Memo = new Memo()
            {
                Date = DateTime.Now,
                Subject = "",
                Text = ""
            };
        }

        private void DisplayMemo()
        {
            var memo = MemoHolder.Current.Memo;
            DateText.Text = string.Format("{0:yyyy MMMMM dd/MM/dd", memo.Date);
            SubjectText.Text = memo.Subject;
            MemoText.Text = memo.Text;
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.        
        }
    }
}
