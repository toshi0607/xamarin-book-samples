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
        }
    }
}
