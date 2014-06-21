using EscapeOfKinokoForest.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using EscapeOfKinokoForest.Views.Stage001;
using Windows.ApplicationModel.Resources;

namespace EscapeOfKinokoForest.Views
{
    /// <summary>
    /// メインページ（各ページはここに配置されたmainFrameに表示するように変更）
    /// </summary>
    public sealed partial class MainFrame : Page
    {
        public MainFrame()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            this.initGame();
        }

        public void initGame()
        {
            ScreenManager.resource = new ResourceLoader();

            this.me.Source = new Uri(ScreenManager.resource.GetString("SOUND_OPENING"));
            this.me.Play();

            this.mainFrame.Navigate(typeof(TopPage), this);

            FlagData.init();
        }

        public void gameStart()
        {
#if WINDOWS_PHONE_APP
            this.mainFrame.Navigate(typeof(InputNamePhonePage), this);           
#else 
            this.mainFrame.Navigate(typeof(InputNamePage), this);
#endif
        }

        internal void endNameInput()
        {
            this.mainFrame.Navigate(typeof(PreGamePage), this);
        }

        internal void goStage001()
        {
            // BGM変更 
            this.me.Stop();
            this.me.Source = new Uri(ScreenManager.resource.GetString("SOUND_GAME_MAIN"));
            this.me.Play();

            this.mainFrame.Navigate(typeof(stage001), this);
        }

        internal void gameClear()
        {
            // BGM変更 
            this.me.Stop();
            this.me.Source = new Uri(ScreenManager.resource.GetString("SOUND_GOLE"));
            this.me.Play();
            this.mainFrame.Navigate(typeof(GoalPage), this);
        }
    }
}
