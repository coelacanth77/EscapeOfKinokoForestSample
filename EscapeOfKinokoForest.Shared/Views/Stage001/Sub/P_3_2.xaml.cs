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
    /// <summary>
    /// きのこの家ページクラス
    /// </summary>
    public sealed partial class P_3_2 : Page
    {
        public int level = 1;

        public P_3_2()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.me2.Source = new Uri(ScreenManager.resource.GetString("SOUND_CHANGE_SCENE"));
            this.me2.Play();

            if (FlagData.is_item5_get == true)
            {
                this.message.Text = ScreenManager.resource.GetString("TEXT_NOTHING");
            }
        }

        private void backBtn_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(stage001));
        }

        private void getItemRect1_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (FlagData.is_item5_get == true)
            {
                return;
            }

            if (level == 1)
            {
                level = 2;
                message.Text = "いち！";
            }
            else
            {
                level = 1;
            }
        }

        private void getItemRect2_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (FlagData.is_item5_get == true)
            {
                return;
            }
            if (level == 2)
            {
                level = 3;
                message.Text = "に！!";
            }
            else
            {
                level = 1;
                message.Text = ScreenManager.resource.GetString("TEXT_WRONG"); ;
            }
        }

        private void getItemRect3_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (FlagData.is_item5_get == true)
            {
                return;
            }

            if (level == 3)
            {
                level = 4;
                message.Text = "さん！!!";
            }
            else
            {
                level = 1;
                message.Text = ScreenManager.resource.GetString("TEXT_WRONG"); ;
            }
        }

        private void getItemRect4_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (FlagData.is_item5_get == true)
            {
                return;
            }

            if (level == 4)
            {
                level = 2;
                message.Text = "よん!!!!";

                // ポップアップを表示
                this.Popup.message = ScreenManager.resource.GetString("TEXT_PAPER3");
                this.Popup.mainImage.Source = new BitmapImage(new Uri(ScreenManager.resource.GetString("IMAGE_ITEM_005_BG")));

                this.me2.Source = new Uri(ScreenManager.resource.GetString("SOUND_GET_ITEM"));
                this.me2.Play();


                this.Popup.Visibility = Windows.UI.Xaml.Visibility.Visible;

                // フラグを立てる
                FlagData.is_item5_get = true;
            }
            else
            {
                level = 1;
                message.Text = ScreenManager.resource.GetString("TEXT_WRONG");
            }
        }

        private void me_MediaFailed(object sender, ExceptionRoutedEventArgs e)
        {

        }
    }
}
