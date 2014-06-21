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
    public sealed partial class scene003 : UserControl
    {
        public event setMessageHandler setMessage;
        public delegate void setMessageHandler(object sender, EventArgs e);

        public scene003()
        {
            this.InitializeComponent();
        }

        private void point_1_1_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ScreenManager.eventFrame.Visibility = Windows.UI.Xaml.Visibility.Visible;
            ScreenManager.eventFrame.Navigate(typeof(P_1_1));
        }

        private void point_2_1_Tapped(object sender, TappedRoutedEventArgs e)
        {
            // アイテム2を取得して、選択した状態でクリックすると
            if (FlagData.is_item2_get == true && FlagData.is_item3_get == false && FlagData.selected_image_num == 2)
            {
                ScreenManager.eventFrame.Visibility = Windows.UI.Xaml.Visibility.Visible;
                ScreenManager.eventFrame.Navigate(typeof(P_2_1));
            }
            else if (FlagData.is_item2_get == true && FlagData.is_item3_get == true)
            {
                this.setMessage("「飾りを見つけてくれてありがとう」", new EventArgs());

            }
            else
            {
                this.setMessage("何かを探しているようだ", new EventArgs());
            }
        }

        public void settled()
        {
            this.Wall001.Source = new BitmapImage(new Uri("ms-appx:///Assets/Stage001/game03_settled.jpg"));
        }
    }
}
