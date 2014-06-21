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
using Windows.UI.Xaml.Navigation;

namespace EscapeOfKinokoForest.Views.Stage001
{
    public sealed partial class P_4_2 : Page
    {
        public P_4_2()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.me2.Source = new Uri(ScreenManager.resource.GetString("SOUND_CHANGE_SCENE"));
            this.me2.Play();

            FlagData.is_item7_get = true;
        }

        private void backBtn_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ScreenManager.eventFrame.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }
    }
}
