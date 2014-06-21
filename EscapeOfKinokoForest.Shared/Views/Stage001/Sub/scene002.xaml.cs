using EscapeOfKinokoForest.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Media.Imaging;

// ユーザー コントロールのアイテム テンプレートについては、http://go.microsoft.com/fwlink/?LinkId=234236 を参照してください

namespace EscapeOfKinokoForest.Views.Stage001
{
    public sealed partial class scene002 : UserControl
    {
        public Frame eventFrame { set; get; }
        public Popup popup { set; get; }

        public scene002()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// きのこの家
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void point_3_2_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ScreenManager.eventFrame.Visibility = Windows.UI.Xaml.Visibility.Visible;
            ScreenManager.eventFrame.Navigate(typeof(P_3_2));
        }
        
        /// <summary>
        /// ウロがある木
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void point_1_1_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ScreenManager.eventFrame.Visibility = Windows.UI.Xaml.Visibility.Visible;
            ScreenManager.eventFrame.Navigate(typeof(P_1_1));
        }

        /// <summary>
        /// イモムシをタップ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void worm_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (FlagData.is_item2_get == false)
            {
                this.Wall002_showPopup();
            }
        }

        public void settled()
        {
            
        }

        void Wall002_showPopup()
        {
            this.popup.message = ScreenManager.resource.GetString("TEXT_WALL_2");
            this.popup.mainImage.Source = new BitmapImage(new Uri(ScreenManager.resource.GetString("IMAGE_ITEM_002_BG")));
            this.popup.Visibility = Windows.UI.Xaml.Visibility.Visible;

            // フラグ
            FlagData.is_item2_get = true;

            // 背景差し替え
            this.Wall001.Source = new BitmapImage(new Uri(ScreenManager.resource.GetString("IMAGE_SCENE_002_SETTLED")));
        }

        private void dog_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ScreenManager.messageText.Text = "アイテムはタッチすることで「選択」状態になるよ";
        }
    }
}
