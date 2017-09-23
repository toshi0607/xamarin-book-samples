using System;

using Xamarin.Forms;

namespace AdressSearchApp
{
    public partial class AddressSearch : ContentPage
    {
        public AddressSearch()
        {
            InitializeComponent();
            this.Title = "住所検索アプリ";
            getAddressSerchBtn.Clicked += GetAddressSerchBtn_Clicked;

            this.BindingContext = new Address();
        }

        private async void GetAddressSerchBtn_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(AddressEntry.Text) && ((string)AddressEntry.Text).Length == 7)
            {
                Address ad = await Core.getAddressSearchResult(AddressEntry.Text);

                if (ad == null)
                {
                    DisplayAlert("通知", "検索に失敗しました・検索条件を変更して再度検索してください。", "OK");
                    return;
                }
                else
                {
                    this.BindingContext = ad;
                }
            }
            else
            {
                DisplayAlert("警告", "郵便番号は7桁で入力してください。", "OK");
            }
        }
    }
}
