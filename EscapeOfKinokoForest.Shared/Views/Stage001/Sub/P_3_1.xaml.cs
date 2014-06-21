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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

namespace EscapeOfKinokoForest.Views.Stage001
{
    public sealed partial class P_3_1 : Page
    {
        public P_3_1()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.me2.Source = new Uri(ScreenManager.resource.GetString("SOUND_CHANGE_SCENE"));
            this.me2.Play();

            // すでにアイテムを見つけていたら
            if (FlagData.is_item4_get == true)
            {
                this.message.Text = ScreenManager.resource.GetString("TEXT_NOTHING");
            }
        }

        private void backBtn_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ScreenManager.eventFrame.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void getItemRect_Tapped(object sender, TappedRoutedEventArgs e)
        {
            // すでにアイテムを4つけていたら
            if (FlagData.is_item4_get == true)
            {
                return;
            }

            // ポップアップを表示
            this.Popup.message = ScreenManager.resource.GetString("TEXT_WHAT");
            this.Popup.mainImage.Source = new BitmapImage(new Uri(ScreenManager.resource.GetString("IMAGE_ITEM_004_BG")));

            this.me2.Source = new Uri(ScreenManager.resource.GetString("SOUND_GET_ITEM"));
            this.me2.Play();

            this.Popup.Visibility = Windows.UI.Xaml.Visibility.Visible;

            // フラグを立てる
            FlagData.is_item4_get = true;
        }

    }
}
