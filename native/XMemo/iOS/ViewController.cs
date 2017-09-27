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

            SubjectText.EditingChanged += (s, e) =>
            {
                MemoHolder.Current.Memo.Subject = SubjectText.Text;
            };

            MemoText.Changed += (s, e) =>
            {
                MemoHolder.Current.Memo.Text = MemoText.Text;
            };

            SetupDatePicker();

            SaveButton.TouchUpInside += SaveButton_TouchUpInside;

            LoadButton.TouchUpInside += LoadButton_TouchUpInside;
        }

        private void DisplayMemo()
        {
            var memo = MemoHolder.Current.Memo;
            DateText.Text = string.Format("{0:yyyy/MM/dd}", memo.Date);
            SubjectText.Text = memo.Subject;
            MemoText.Text = memo.Text;
        }

        private void SetupDatePicker()
        {
            var doneButton = new UIBarButtonItem("閉じる", UIBarButtonItemStyle.Done,
                (sender, e) => { DateText.ResignFirstResponder(); });
            var toolBar = new UIToolbar()
            {
                BarStyle = UIBarStyle.Default,
                Translucent = true,
                TintColor = null,
            };
            toolBar.SizeToFit();
            toolBar.SetItems(new[]
            {
                new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace),
                doneButton,
            }, true);

            var datePicker = new UIDatePicker()
            {
                Mode = UIDatePickerMode.Date,
            };
            datePicker.ValueChanged += (s, e) =>
            {
                MemoHolder.Current.Memo.Date = (DateTime)datePicker.Date;
                DisplayMemo();
            };

            DateText.InputAccessoryView = toolBar;
            DateText.InputView = datePicker;
        }

        private async void SaveButton_TouchUpInside(object sender, EventArgs e)
        {
            await MemoHolder.Current.SaveAsync();
        }

        private async void LoadButton_TouchUpInside(object sender, EventArgs e)
        {
            await MemoHolder.Current.LoadAsync();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.        
        }
    }
}
