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
    public sealed partial class Popup : UserControl
    {
        public Image mainImage
        {
            get { return this.ItemImage; }
            set { this.ItemImage = value; }
        }

        public String message
        {
            get { return this.messageText.Text; }
            set { this.messageText.Text = value; }
        }

        public String message2
        {
            get { return this.message2Text.Text; }
            set { this.message2Text.Text = value; }
        }

        public Image backBton
        {
            get { return this.backBtn; }
        }

        public Popup()
        {
            this.InitializeComponent();
        }

        private void backBtn_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        public void hideReturnButton()
        {
            backBtn.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }
    }
}
