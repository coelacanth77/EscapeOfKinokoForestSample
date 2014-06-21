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

// 空白ページのアイテム テンプレートについては、http://go.microsoft.com/fwlink/?LinkId=234238 を参照してください

namespace EscapeOfKinokoForest.Views
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class TopPage : Page
    {
        private bool isPageNavigate = false;
        public MainFrame _parentPage { get; set; }

        public TopPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// このページがフレームに表示されるときに呼び出されます。
        /// </summary>
        /// <param name="e">このページにどのように到達したかを説明するイベント データ。Parameter 
        /// プロパティは、通常、ページを構成するために使用します。</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this._parentPage = e.Parameter as MainFrame;
        }

        private void gameStartButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            // 2重クリック防止
            if (this.isPageNavigate == true)
            {
                return;
            }

            this.Storyboard1.Completed += Storyboard1_Completed;
            this.Storyboard1.Begin();

            this.isPageNavigate = true;
        }

        void Storyboard1_Completed(object sender, object e)
        {
            this._parentPage.gameStart();
        }
    }
}
