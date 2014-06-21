using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using EscapeOfKinokoForest.Common;
using EscapeOfKinokoForest.Models;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// 空白ページのアイテム テンプレートについては、http://go.microsoft.com/fwlink/?LinkId=234238 を参照してください

namespace EscapeOfKinokoForest.Views
{
    public sealed partial class GoalPage : Page
    {
        public MainFrame _parentPage { get; set; }
        public GoalPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this._parentPage = e.Parameter as MainFrame;

            this.me.Source = new Uri("ms-appx:///Assets/Sounds/goal.mp3");
            this.me.Play();

            this.showRanking.Begin();

            // これまでのランキングを取得
            List<ResultData> oldList = getRankingFromSettings();

            // 今回の記録を取得
            ResultData result = new ResultData() { name = UserData.name, span = FlagData.span };

            // ランキングを集計
            oldList.Add(result);

            var newListEnumrable = oldList.OrderBy(x => x.span).Take(10);

            List<ResultData> newList = new List<ResultData>(newListEnumrable);

            // ランキング表示
            this.displayRanking(newList);

            // 保存する
            this.saveRankingToSettings(newList);

            foreach (var data in newList)
            {
                System.Diagnostics.Debug.WriteLine(data.name);
                System.Diagnostics.Debug.WriteLine(data.span.ToString(@"hh'時間'mm'分'ss'秒'"));
            }
        }

        private void displayRanking(List<ResultData> list)
        {
            int i = 1;

            foreach (var data in list)
            {
                switch (i)
                {
                    case 1:
                        this.no1name.Text = data.name;
                        this.no1time.Text = data.span.ToString(@"hh\:mm\:ss");
                        break;

                    case 2:
                        this.no2name.Text = data.name;
                        this.no2time.Text = data.span.ToString(@"hh\:mm\:ss");
                        break;

                    case 3:
                        this.no3name.Text = data.name;
                        this.no3time.Text = data.span.ToString(@"hh\:mm\:ss");
                        break;

                    case 4:
                        this.no4name.Text = data.name;
                        this.no4time.Text = data.span.ToString(@"hh\:mm\:ss");
                        break;

                    case 5:
                        this.no5name.Text = data.name;
                        this.no5time.Text = data.span.ToString(@"hh\:mm\:ss");
                        break;

                    case 6:
                        this.no6name.Text = data.name;
                        this.no6time.Text = data.span.ToString(@"hh\:mm\:ss");
                        break;

                    case 7:
                        this.no7name.Text = data.name;
                        this.no7time.Text = data.span.ToString(@"hh\:mm\:ss");
                        break;

                    case 8:
                        this.no8name.Text = data.name;
                        this.no8time.Text = data.span.ToString(@"hh\:mm\:ss");
                        break;

                    case 9:
                        this.no9name.Text = data.name;
                        this.no9time.Text = data.span.ToString(@"hh\:mm\:ss");
                        break;

                    case 10:
                        this.no10name.Text = data.name;
                        this.no10time.Text = data.span.ToString(@"hh\:mm\:ss");
                        break;
                }

                i++;
            }
        }

        private void saveRankingToSettings(List<ResultData> list)
        {
            var settings = Windows.Storage.ApplicationData.Current.LocalSettings;

            int i = 1;

            foreach (var data in list)
            {
                using (MemoryStream stream = new MemoryStream())
                {

                    var serializer = new DataContractSerializer(data.GetType());
                    serializer.WriteObject(stream, data);
                    stream.Position = 0;

                    using (StreamReader reader = new StreamReader(stream))
                    {
                        settings.Values[i.ToString()] = reader.ReadToEnd();
                    }
                    i++;
                }
            }
        }

        private List<ResultData> getRankingFromSettings()
        {
            // ランキングを集計
            var settings = Windows.Storage.ApplicationData.Current.LocalSettings;

            ResultData data = new ResultData() { };

            List<ResultData> list = new List<ResultData>();

            for (var i = 1; i < 11; i++ )
            {
                var key = i.ToString();

                if (settings.Values[key] != null)
                {
                    var resultStr = (string)settings.Values[i.ToString()];

                    byte[] byteArr = System.Text.Encoding.UTF8.GetBytes(resultStr);
                    var stream = new MemoryStream(byteArr);

                    var serializer = new DataContractSerializer(data.GetType());

                    data = (ResultData)serializer.ReadObject(stream);

                    list.Add(data);
                }
                else
                {
                    i = 999;
                }
            }

            return list;
        }

        private void Image_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this._parentPage.initGame();
        }
    }
}
