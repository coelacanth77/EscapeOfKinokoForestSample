﻿using System;
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
    /// 宝石を渡した
    /// </summary>
    public sealed partial class P_2_1 : Page
    {
        public P_2_1()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.me2.Source = new Uri(ScreenManager.resource.GetString("SOUND_CHANGE_SCENE"));
            this.me2.Play();
        }

        private void backBtn_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ScreenManager.eventFrame.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void backNext_Tapped(object sender, TappedRoutedEventArgs e)
        {
            // アイテム入手ポップアップ表示
            // すでにアイテムを見つけていたら
            if (FlagData.is_item3_get == true)
            {
                return;
            }

            // ポップアップを表示
            this.Popup.message = ScreenManager.resource.GetString("TEXT_PAPER2");
            this.Popup.mainImage.Source = new BitmapImage(new Uri(ScreenManager.resource.GetString("IMAGE_ITEM_003_BG")));


            this.me2.Source = new Uri(ScreenManager.resource.GetString("SOUND_GET_ITEM"));
            this.me2.Play();

            this.Popup.Visibility = Windows.UI.Xaml.Visibility.Visible;

            // フラグを立てる
            FlagData.is_item3_get = true;

            // 戻るボタン表示
            this.backBtn.Visibility = Windows.UI.Xaml.Visibility.Visible;
            this.backNext.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }
    }
}
