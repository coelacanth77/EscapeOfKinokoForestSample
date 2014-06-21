using EscapeOfKinokoForest.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Devices.Sensors;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using EscapeOfKinokoForest.Common;

namespace EscapeOfKinokoForest.Views.Stage001
{
    /// <summary>
    /// ステージ1用のページクラス
    /// </summary>
    public sealed partial class stage001 : Page
    {
        /// <summary>
        /// 親ページ
        /// ゲーム全体を制御するフレーム
        /// 本ページはゲームのstage1制御用のページ
        /// </summary>
        public MainFrame _parentPage { get; set; }

        /// <summary>
        /// タッチで操作するモードか端末のコンパスを利用するモードか
        /// </summary>
        private gameMode _mode = gameMode.touch;

        /// <summary>
        /// コンパス
        /// </summary>
        private Compass _compass;

        /// <summary>
        /// 磁北からの角度を保存する一時変数
        /// </summary>
        private double _preHeadingMagnetic;

        /// <summary>
        /// ステージの幅
        /// </summary>
        private readonly int STAGE_WIDTH = 1920;

        private DispatcherTimer _timer;

        private bool _is_item1_get_checked = false;
        private bool _is_item2_get_checked = false;
        private bool _is_item3_get_checked = false;
        private bool _is_item4_get_checked = false;
        private bool _is_item5_get_checked = false;
        private bool _is_item6_get_checked = false;

        public stage001()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.name.Text = UserData.name + "さん";

            // 親ページを保存
            this._parentPage = e.Parameter as MainFrame;
            
            // イベント用のフレームをstaticに保持
            ScreenManager.eventFrame = this.eventFrame;
            ScreenManager.messageText = this.message;

            this._compass = Compass.GetDefault();
            if (this._compass != null)
            {
                this._mode = gameMode.compass;

                this._compass.ReadingChanged += compass_ReadingChanged;
            }
            else
            {
                this._mode = gameMode.touch;
            }

            this.Wall002.eventFrame = this.eventFrame;
            this.Wall002.popup = this.Popup;

            this.Wall001.showPopup += Wall001_showPopup;
            this.Wall001_2.showPopup += Wall001_showPopup;

            this.Wall003.setMessage += Wall003_setMessage;
            this.Wall003_2.setMessage += Wall003_setMessage;

            this.Wall004.gameClear += Wall004_gameClear;
            this.Wall004_2.gameClear += Wall004_gameClear;

            if (FlagData.setStartTime == false)
            {
                FlagData.startTime = DateTime.Now;
                FlagData.setStartTime = true;
            }

            FlagData.selected_image_num = 0;

            if (this._timer == null)
            {
                this._timer = new DispatcherTimer();
                this._timer.Tick += _flagChecker;
                this._timer.Interval = new TimeSpan(0, 0, 0, 1);
                this._timer.Start();
            }

            if (this._mode == gameMode.touch && FlagData.transform != null)
            {
                var transform = FlagData.transform;

                this.Wall001.RenderTransform = transform;
                this.Wall002.RenderTransform = transform;
                this.Wall003.RenderTransform = transform;
                this.Wall003_2.RenderTransform = transform;
                this.Wall004.RenderTransform = transform;
                this.Wall004_2.RenderTransform = transform;
                this.Wall001_2.RenderTransform = transform;
            }
        }

        void _flagChecker(object sender, object e)
        {
            this.update();
        }

        void Wall004_gameClear(object sender, EventArgs e)
        {
            this._parentPage.gameClear();
        }

        /// <summary>
        /// Flagを元に表示を更新する
        /// </summary>
        public void update()
        {
            // フラグを確認あればアイテムを表示
            if (FlagData.is_item1_get == true && this._is_item1_get_checked == false)
            {
                this.item1Image.Source = new BitmapImage(new Uri(ScreenManager.resource.GetString("IMAGE_ITEM_001")));
                this._is_item1_get_checked = true;
            }

            //　フラグ2はアイテム表示と背景差し替え
            if (FlagData.is_item2_get == true && this._is_item2_get_checked == false)
            {
                this.item2Image.Source = new BitmapImage(new Uri(ScreenManager.resource.GetString("IMAGE_ITEM_002")));
                this.Wall002.settled();
                this._is_item2_get_checked = true;
            }

            //　フラグ3はアイテム表示と背景差し替え
            if (FlagData.is_item3_get == true && this._is_item3_get_checked == false)
            {
                this.item3Image.Source = new BitmapImage(new Uri(ScreenManager.resource.GetString("IMAGE_ITEM_003")));
                this.Wall003.settled();
                this.Wall003_2.settled();
                this._is_item3_get_checked = true;
            }

            if (FlagData.is_item4_get == true && this._is_item4_get_checked == false)
            {
                this.item4Image.Source = new BitmapImage(new Uri(ScreenManager.resource.GetString("IMAGE_ITEM_004")));
                this._is_item4_get_checked = true;
            }

            if (FlagData.is_item5_get == true && this._is_item5_get_checked == false)
            {
                this.item5Image.Source = new BitmapImage(new Uri(ScreenManager.resource.GetString("IMAGE_ITEM_005")));
                this._is_item5_get_checked = true;
            }

            if (FlagData.is_item6_get == true && this._is_item6_get_checked == false)
            {
                this.item6Image.Source = new BitmapImage(new Uri(ScreenManager.resource.GetString("IMAGE_ITEM_006")));
                this.Wall001.settled();
                this.Wall001_2.settled();
                this._is_item6_get_checked = true;
            }

        }


        private void gameStage_ManipulationStarted(object sender, ManipulationStartedRoutedEventArgs e)
        {
            
        }

        private async void gameStage_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            if (this._mode == gameMode.compass)
            {
                return;
            }

            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, delegate
            {
                TranslateTransform translate = new TranslateTransform();
                double translateValue;

                translateValue = e.Cumulative.Translation.X / 400;

                if (this.Wall001.RenderTransform != null && (this.Wall001.RenderTransform as TranslateTransform) != null)
                {
                    translate.X = translateValue * (STAGE_WIDTH / 90) + (this.Wall001.RenderTransform as TranslateTransform).X;
                }
                else
                {
                    translate.X = translateValue * (STAGE_WIDTH / 90);
                }
                // 画面右端に行ったら位置を戻す
                if (translate.X < -STAGE_WIDTH *4)
                {
                    translate.X = translate.X + STAGE_WIDTH * 4;
                }

                // 画面左端に行ったら位置を戻す
                if (translate.X > STAGE_WIDTH)
                {
                    translate.X = translate.X - STAGE_WIDTH * 4;
                }

                this.Wall001.RenderTransform = translate;
                this.Wall002.RenderTransform = translate;
                this.Wall003.RenderTransform = translate;
                this.Wall003_2.RenderTransform = translate;
                this.Wall004.RenderTransform = translate;
                this.Wall004_2.RenderTransform = translate;
                this.Wall001_2.RenderTransform = translate;

                FlagData.transform = translate;
            }
            );
        }

        void Wall003_setMessage(object sender, EventArgs e)
        {
            String message = (string)sender;

            this.message.Text = message;
        }

        void Wall001_showPopup(object sender, EventArgs e)
        {
            this.Popup.message = ScreenManager.resource.GetString("TEXT_CLOVER");
            this.Popup.mainImage.Source = new BitmapImage(new Uri(ScreenManager.resource.GetString("IMAGE_ITEM_006_BG")));
            this.Popup.Visibility = Windows.UI.Xaml.Visibility.Visible;

            this.me2.Source = new Uri(ScreenManager.resource.GetString("SOUND_GET_ITEM"));
            this.me2.Play();

            // 背景差し替え
            this.Wall001.settled();
            this.Wall001_2.settled();

            // フラグ
            FlagData.is_item6_get = true;
            this.item6Image.Source = new BitmapImage(new Uri(ScreenManager.resource.GetString("IMAGE_ITEM_006")));
        }

        async void compass_ReadingChanged(Compass sender, CompassReadingChangedEventArgs args)
        {
            if (this._mode == gameMode.touch)
            {
                return;
            }

            CompassReading reading = args.Reading;

            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, delegate
            {
                // 壁の移動
                var diff = reading.HeadingMagneticNorth - this._preHeadingMagnetic;

                TranslateTransform translate = new TranslateTransform();

                double translateValue;

                if (reading.HeadingMagneticNorth > 180)
                {
                    translateValue = -(reading.HeadingMagneticNorth - 360);
                }
                else
                {
                    translateValue = -reading.HeadingMagneticNorth;
                }

                translate.X = translateValue * (STAGE_WIDTH / 90);

                this.Wall001.RenderTransform = translate;
                this.Wall002.RenderTransform = translate;
                this.Wall003.RenderTransform = translate;
                this.Wall003_2.RenderTransform = translate;
                this.Wall004.RenderTransform = translate;
                this.Wall004_2.RenderTransform = translate;
                this.Wall001_2.RenderTransform = translate;

                this._preHeadingMagnetic = reading.HeadingMagneticNorth;
            }
            );
        }

        private void itemTapped(object sender, TappedRoutedEventArgs e)
        {
            Image img = sender as Image;

            // 一旦すべての画像を未選択に
            switch (FlagData.selected_image_num) 
            {
                case 1:
                   this._is_item1_get_checked = false;
                   break;

                case 2:
                   this._is_item2_get_checked = false;
                   break;

                case 3:
                   this._is_item3_get_checked = false;
                   break;

                case 4:
                   this._is_item4_get_checked = false;
                   break;

                case 5:
                   this._is_item5_get_checked = false;
                   break;
                case 6:
                   this._is_item6_get_checked = false;
                   break;
            }

            FlagData.selected_image_num = 0;
            this.update();

            if (img.Name == this.item1Image.Name && FlagData.is_item1_get == true)
            {
                this.item1Image.Source = new BitmapImage(new Uri(ScreenManager.resource.GetString("IMAGE_ITEM_001_ACTIVE")));
                FlagData.selected_image_num = 1;

            }
            else if (img.Name == this.item2Image.Name && FlagData.is_item2_get == true)
            {
                this.item2Image.Source = new BitmapImage(new Uri(ScreenManager.resource.GetString("IMAGE_ITEM_002_ACTIVE")));
                FlagData.selected_image_num = 2;

            }
            else if (img.Name == this.item3Image.Name && FlagData.is_item3_get == true)
            {
                this.item3Image.Source = new BitmapImage(new Uri(ScreenManager.resource.GetString("IMAGE_ITEM_003_ACTIVE")));
                FlagData.selected_image_num = 3;

            }
            else if (img.Name == this.item4Image.Name && FlagData.is_item4_get == true)
            {
                this.item4Image.Source = new BitmapImage(new Uri(ScreenManager.resource.GetString("IMAGE_ITEM_004_ACTIVE")));
                FlagData.selected_image_num = 4;

            }
            else if (img.Name == this.item5Image.Name && FlagData.is_item5_get == true)
            {
                this.item5Image.Source = new BitmapImage(new Uri(ScreenManager.resource.GetString("IMAGE_ITEM_005_ACTIVE")));
                FlagData.selected_image_num = 5;

            }
            else if (img.Name == this.item6Image.Name && FlagData.is_item6_get == true)
            {
                this.item6Image.Source = new BitmapImage(new Uri(ScreenManager.resource.GetString("IMAGE_ITEM_006_ACTIVE")));
                FlagData.selected_image_num = 6;
            }
        }

        /// <summary>
        /// アイテム確認ボタンをクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutItemButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (FlagData.selected_image_num == 1)
            {
                this.Popup.message = ScreenManager.resource.GetString("TEXT_001_HINT");
                this.Popup.mainImage.Source = new BitmapImage(new Uri(ScreenManager.resource.GetString("IMAGE_ITEM_001_BG")));
                this.Popup.Visibility = Windows.UI.Xaml.Visibility.Visible;
            }

            if (FlagData.selected_image_num == 2)
            {
                if (FlagData.is_item3_get == false)
                {
                    this.Popup.message = ScreenManager.resource.GetString("TEXT_002_HINT");
                }
                else
                {
                    this.Popup.message = ScreenManager.resource.GetString("TEXT_002_HINT2");
                }
                this.Popup.mainImage.Source = new BitmapImage(new Uri(ScreenManager.resource.GetString("IMAGE_ITEM_002_BG")));
                this.Popup.Visibility = Windows.UI.Xaml.Visibility.Visible;
            }

            if (FlagData.selected_image_num == 3)
            {
                this.Popup.message = ScreenManager.resource.GetString("TEXT_003_HINT");

                this.Popup.mainImage.Source = new BitmapImage(new Uri(ScreenManager.resource.GetString("IMAGE_ITEM_003_BG")));
                this.Popup.Visibility = Windows.UI.Xaml.Visibility.Visible;
            }

            if (FlagData.selected_image_num == 4)
            {
                this.Popup.message = ScreenManager.resource.GetString("TEXT_004_HINT");

                this.Popup.mainImage.Source = new BitmapImage(new Uri(ScreenManager.resource.GetString("IMAGE_ITEM_004_BG")));
                this.Popup.Visibility = Windows.UI.Xaml.Visibility.Visible;
            }

            if (FlagData.selected_image_num == 5)
            {
                this.Popup.message = ScreenManager.resource.GetString("TEXT_005_HINT");

                this.Popup.mainImage.Source = new BitmapImage(new Uri(ScreenManager.resource.GetString("IMAGE_ITEM_005_BG")));
                this.Popup.Visibility = Windows.UI.Xaml.Visibility.Visible;
            }

            if (FlagData.selected_image_num == 6)
            {
                this.Popup.message = ScreenManager.resource.GetString("TEXT_006_HINT");

                this.Popup.mainImage.Source = new BitmapImage(new Uri(ScreenManager.resource.GetString("IMAGE_ITEM_006_BG")));
                this.Popup.Visibility = Windows.UI.Xaml.Visibility.Visible;
            }
        }
    }

    enum gameMode { touch, compass }
}
