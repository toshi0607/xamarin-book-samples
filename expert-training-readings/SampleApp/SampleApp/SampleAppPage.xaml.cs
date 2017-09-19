using Xamarin.Forms;

namespace SampleApp
{
    public partial class SampleAppPage : TabbedPage
    {
        public SampleAppPage()
        {
            InitializeComponent();

            SampleButton1.Clicked += (sender, e) =>
            {
                DisplayAlert("通知", "タブ1のボタン1がタップされました", "OK");
            };

            SampleButton2.Clicked += (sender, e) =>
            {
                DisplayAlert("警告", "タブ1のボタン2がタップされました", "OK");
            };

            Authentication.Clicked += (sender, e) =>
            {
                if (!string.IsNullOrEmpty(entryAccount.Text))
                {
                    if (!string.IsNullOrEmpty(entryPassword.Text))
                    {
                        DisplayAlert("通知", $"{entryAccount.Text}を認証しました", "OK");
                    }
                    else
                    {
                        DisplayAlert("警告", "パスワードを入力してください", "OK");
                    }
                }
                else
                {
                    DisplayAlert("警告", "アカウントを入力してください", "OK");
                }
            };

            Clear.Clicked += (sender, e) =>
            {
                entryAccount.Text = "";
                entryPassword.Text = "";
            };
        }
    }
}
