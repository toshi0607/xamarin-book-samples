using System;
using Xamarin.Forms;

namespace StartXamarin
{
    public partial class StartXamarinPage : ContentPage
    {
        public StartXamarinPage()
        {
            InitializeComponent();
            this.btn1.Clicked += Btn1_Clicked;
        }

        private void Btn1_Clicked(object sender, EventArgs e)
        {
            this.text1.Text = "「" + this.entry1.Text + "」が入力されました";
        }
    }
}
