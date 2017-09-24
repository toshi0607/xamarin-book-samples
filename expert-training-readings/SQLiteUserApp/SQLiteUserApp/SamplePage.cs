using System;
using Xamarin.Forms;
using SQLiteSample;

namespace SQLiteUserApp
{
    public class SamplePage : ContentPage
    {
        readonly SqliteControl wSQLiteControl = new SqliteControl();

        public SamplePage()
        {
            var wListView = new ListView
            {
                ItemsSource = wSQLiteControl.GetItems(),
                ItemTemplate = new DataTemplate(typeof(TextCell))
            };
            wListView.ItemTemplate.SetBinding(TextCell.TextProperty, "Text");
            wListView.ItemTemplate.SetBinding(TextCell.DetailProperty, new Binding("InsertDate", stringFormat: "{0:777/MM/dd hh:mm}"));

            wListView.ItemTapped += async (s, a) =>
            {
                var wItem = (SQLiteItem)a.Item;
                if (await DisplayAlert("削除しますか", wItem.Text, "はい", "いいえ"))
                {
                    wSQLiteControl.DeleteItem(wItem);
                    wListView.ItemsSource = wSQLiteControl.GetItems();
                }
            };

            var wLabel1 = new Label
            {
                Text = "サンプルアプリ（データ登録・削除）",
                BackgroundColor = Color.Navy,
                TextColor = Color.White,
                WidthRequest = 600
            };

            var wLabel2 = new Label
            {
                Text = "登録データ一覧",
                BackgroundColor = Color.Gray,
                TextColor = Color.White,
                WidthRequest = 300
            };

            var wEntry = new Entry
            {
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            var wButtons = new Button
            {
                WidthRequest = 60,
                TextColor = Color.White,
                Text = "登録"
            };

            wButtons.Clicked += (s, a) =>
            {
                if (!string.IsNullOrEmpty(wEntry.Text))
                {
                    var item = new SQLiteItem
                    {
                        Text = wEntry.Text,
                        InsertDate = DateTime.Now
                    };
                    wSQLiteControl.InsertItem(item);
                    wListView.ItemsSource = wSQLiteControl.GetItems();
                    wEntry.Text = "";
                }
            };

            Content = new StackLayout
            {
                Padding = new Thickness(0,Device.OnPlatform(20,0,0),0,0),
                Children = {
                    wLabel1,
                    new StackLayout {
                        BackgroundColor = Color.Green,
                        Padding = 5,
                        Orientation = StackOrientation.Horizontal,
                        Children = {
                            wEntry, wButtons
                        }
                    },
                    wLabel2,
                    wListView
                }
            };
        }
    }
}

