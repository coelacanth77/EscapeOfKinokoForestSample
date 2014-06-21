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
    public sealed partial class P_5_1 : Page
    {
        public scene004 _parent { get; set; }

        private bool button1 = false;
        private bool button2 = false;
        private bool button3 = false;
        private bool button4 = false;
        private bool button5 = false;
        private bool button6 = false;
        private bool button7 = false;
        private bool button8 = false;
        private bool button9 = false;

        public P_5_1()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this._parent = e.Parameter as scene004;
            this.me2.Source = new Uri(ScreenManager.resource.GetString("SOUND_CHANGE_SCENE"));
            this.me2.Play();
        }

        private void backBtn_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ScreenManager.eventFrame.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void key_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Image img = sender as Image;

            if (img.Name == "key1")
            {
                if (this.button1 == false)
                {
                    this.button1 = true;
                    img.Source = new BitmapImage(new Uri("ms-appx:///Assets/Stage001/point/point5_parts/point5_Btn1_active.png"));
                }
                else
                {
                    this.button1 = false;
                    img.Source = new BitmapImage(new Uri("ms-appx:///Assets/Stage001/point/point5_parts/point5_Btn1.png"));
                }
            }
            if (img.Name == "key2")
            {
                if (this.button2 == false)
                {
                    this.button2 = true;
                    img.Source = new BitmapImage(new Uri("ms-appx:///Assets/Stage001/point/point5_parts/point5_Btn2_active.png"));
                }
                else
                {
                    this.button2 = false;
                    img.Source = new BitmapImage(new Uri("ms-appx:///Assets/Stage001/point/point5_parts/point5_Btn2.png"));
                }
            }
            if (img.Name == "key3")
            {
                if (this.button3 == false)
                {
                    this.button3 = true;
                    img.Source = new BitmapImage(new Uri("ms-appx:///Assets/Stage001/point/point5_parts/point5_Btn3_active.png"));
                }
                else
                {
                    this.button3 = false;
                    img.Source = new BitmapImage(new Uri("ms-appx:///Assets/Stage001/point/point5_parts/point5_Btn3.png"));
                }
            }
            if (img.Name == "key4")
            {
                if (this.button4 == false)
                {
                    this.button4 = true;
                    img.Source = new BitmapImage(new Uri("ms-appx:///Assets/Stage001/point/point5_parts/point5_Btn4_active.png"));
                }
                else
                {
                    this.button4 = false;
                    img.Source = new BitmapImage(new Uri("ms-appx:///Assets/Stage001/point/point5_parts/point5_Btn4.png"));
                }
            }
            if (img.Name == "key5")
            {
                if (this.button5 == false)
                {
                    this.button5 = true;
                    img.Source = new BitmapImage(new Uri("ms-appx:///Assets/Stage001/point/point5_parts/point5_Btn5_active.png"));
                }
                else
                {
                    this.button5 = false;
                    img.Source = new BitmapImage(new Uri("ms-appx:///Assets/Stage001/point/point5_parts/point5_Btn5.png"));
                }
            }
            if (img.Name == "key6")
            {
                if (this.button6 == false)
                {
                    this.button6 = true;
                    img.Source = new BitmapImage(new Uri("ms-appx:///Assets/Stage001/point/point5_parts/point5_Btn6_active.png"));
                }
                else
                {
                    this.button6 = false;
                    img.Source = new BitmapImage(new Uri("ms-appx:///Assets/Stage001/point/point5_parts/point5_Btn6.png"));
                }
            }
            if (img.Name == "key7")
            {
                if (this.button7 == false)
                {
                    this.button7 = true;
                    img.Source = new BitmapImage(new Uri("ms-appx:///Assets/Stage001/point/point5_parts/point5_Btn7_active.png"));
                }
                else
                {
                    this.button7 = false;
                    img.Source = new BitmapImage(new Uri("ms-appx:///Assets/Stage001/point/point5_parts/point5_Btn7.png"));
                }
            }
            if (img.Name == "key8")
            {
                if (this.button8 == false)
                {
                    this.button8 = true;
                    img.Source = new BitmapImage(new Uri("ms-appx:///Assets/Stage001/point/point5_parts/point5_Btn8_active.png"));
                }
                else
                {
                    this.button8 = false;
                    img.Source = new BitmapImage(new Uri("ms-appx:///Assets/Stage001/point/point5_parts/point5_Btn8.png"));
                }
            }
            if (img.Name == "key9")
            {
                if (this.button9 == false)
                {
                    this.button9 = true;
                    img.Source = new BitmapImage(new Uri("ms-appx:///Assets/Stage001/point/point5_parts/point5_Btn9_active.png"));
                }
                else
                {
                    this.button9 = false;
                    img.Source = new BitmapImage(new Uri("ms-appx:///Assets/Stage001/point/point5_parts/point5_Btn9.png"));
                }
            }
            if (img.Name == "keyEnter")
            {
                if (
                    this.button1 == true &&
                    this.button2 == false &&
                    this.button3 == false &&
                    this.button4 == true &&
                    this.button5 == false &&
                    this.button6 == true &&
                    this.button7 == false &&
                    this.button8 == true &&
                    this.button9 == false

                    )
                {
                    this.Popup.message = "出口が開いた！！ 脱出成功！！";

                    // クリアまでにかかった時間を保持
                    FlagData.span = DateTime.Now - FlagData.startTime;

                    this.me.Stop();
                    this.me.Source = new Uri("ms-appx:///Assets/Sounds/goal.mp3");
                    this.me.Play();

                    this.me2.Source = new Uri("ms-appx:///Assets/Sounds/success.mp3");
                    this.me2.Play();

                    this.Popup.message2 = "クリアタイム　" + (DateTime.Now - FlagData.startTime).ToString(@"hh'時間'mm'分'ss'秒！！'");
                    this.Popup.mainImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/Stage001/goalImg.gif"));

                    this.Popup.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    this.Popup.hideReturnButton();

                    this.backBtn.Visibility = Windows.UI.Xaml.Visibility.Collapsed;

                    this.Popup.Tapped += mainStage_Tapped;
                }
                else
                {
                    this._clearAll();
                    this.me2.Source = new Uri("ms-appx:///Assets/Sounds/false.mp3");
                    this.me2.Play();
                }
            }
            if (img.Name == "keyClear")
            {
                this._clearAll();
            }
        }

        /// <summary>
        /// クリア画面表示後に画面をタップしたら結果表示画面に
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void mainStage_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this._parent.gameClearCall();
        }

        private void _clearAll()
        {
            this.button1 = false;
            this.button2 = false;
            this.button3 = false;
            this.button4 = false;
            this.button5 = false;
            this.button6 = false;
            this.button7 = false;
            this.button8 = false;
            this.button9 = false;

            this.key1.Source = new BitmapImage(new Uri("ms-appx:///Assets/Stage001/point/point5_parts/point5_Btn1.png"));
            this.key2.Source = new BitmapImage(new Uri("ms-appx:///Assets/Stage001/point/point5_parts/point5_Btn2.png"));
            this.key3.Source = new BitmapImage(new Uri("ms-appx:///Assets/Stage001/point/point5_parts/point5_Btn3.png"));
            this.key4.Source = new BitmapImage(new Uri("ms-appx:///Assets/Stage001/point/point5_parts/point5_Btn4.png"));
            this.key5.Source = new BitmapImage(new Uri("ms-appx:///Assets/Stage001/point/point5_parts/point5_Btn5.png"));
            this.key6.Source = new BitmapImage(new Uri("ms-appx:///Assets/Stage001/point/point5_parts/point5_Btn6.png"));
            this.key7.Source = new BitmapImage(new Uri("ms-appx:///Assets/Stage001/point/point5_parts/point5_Btn7.png"));
            this.key8.Source = new BitmapImage(new Uri("ms-appx:///Assets/Stage001/point/point5_parts/point5_Btn8.png"));
            this.key9.Source = new BitmapImage(new Uri("ms-appx:///Assets/Stage001/point/point5_parts/point5_Btn9.png"));
        }
    }
}
