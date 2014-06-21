using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EscapeOfKinokoForest.Models;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

namespace EscapeOfKinokoForest.Views.Stage001
{
    /// <summary>
    /// メインマップ001
    /// </summary>
    public sealed partial class scene001 : UserControl
    {
        public event showPopupHandler showPopup;
        public delegate void showPopupHandler(object sender, EventArgs e);

        public scene001()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// どんぐりの家をタッチ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void point_3_1_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ScreenManager.eventFrame.Visibility = Windows.UI.Xaml.Visibility.Visible;
            ScreenManager.eventFrame.Navigate(typeof(P_3_1));
        }

        /// <summary>
        /// 四つ葉のクローバーを取得
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void getItem6_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (FlagData.is_item6_get == false)
            {
                this.showPopup("clobar", new EventArgs());
            }
        }

        /// <summary>
        /// 四つ葉のクローバー取得済み
        /// </summary>
        public void settled()
        {
            this.Wall001.Source = new BitmapImage(new Uri(ScreenManager.resource.GetString("IMAGE_GAME01_SETTLED")));
        }

        private void usagi_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ScreenManager.messageText.Text = "ゴールには鍵となる数字がいくつか必要らしいよ";
        }
    }
}
