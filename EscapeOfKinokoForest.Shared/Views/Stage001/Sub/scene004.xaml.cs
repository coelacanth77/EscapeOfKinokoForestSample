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

// ユーザー コントロールのアイテム テンプレートについては、http://go.microsoft.com/fwlink/?LinkId=234236 を参照してください

namespace EscapeOfKinokoForest.Views.Stage001
{
    public sealed partial class scene004 : UserControl
    {
        public event gameClearHandler gameClear;
        public delegate void gameClearHandler(object sender, EventArgs e);

        public scene004()
        {
            this.InitializeComponent();
        }

        private void point_4_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ScreenManager.eventFrame.Visibility = Windows.UI.Xaml.Visibility.Visible;
            if (FlagData.is_item7_get == true || FlagData.is_item6_get == true && FlagData.selected_image_num == 6)
            {
                ScreenManager.eventFrame.Navigate(typeof(P_4_2));
            }
            else
            {
                ScreenManager.eventFrame.Navigate(typeof(P_4_1));
            }
        }

        private void point_5_1_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ScreenManager.eventFrame.Visibility = Windows.UI.Xaml.Visibility.Visible;
            ScreenManager.eventFrame.Navigate(typeof(P_5_1), this);
        }

        internal void gameClearCall()
        {
            this.gameClear(this, new EventArgs());
        }

        private void kirin_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ScreenManager.messageText.Text = "クローバーは4つ葉じゃないとね";
        }
    }
}
