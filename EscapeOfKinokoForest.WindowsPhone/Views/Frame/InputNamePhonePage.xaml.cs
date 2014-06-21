using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EscapeOfKinokoForest.Common;
using EscapeOfKinokoForest.Models;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// 空白ページのアイテム テンプレートについては、http://go.microsoft.com/fwlink/?LinkId=234238 を参照してください

namespace EscapeOfKinokoForest.Views
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class InputNamePhonePage : Page
    {
        public MainFrame _parentPage { get; set; }

        private string name = "";

        public InputNamePhonePage()
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

            this.Storyboard1.Begin();
        }


        private void nameOKButton_Click(object sender, RoutedEventArgs e)
        {
            UserData.name = this.name;

            this._parentPage.endNameInput();
        }

        private void nameNGButton_Click(object sender, RoutedEventArgs e)
        {
            this.announceText.Text = "名前を入力してください（9文字まで）\n入力後は「入力おわり」を押してください。";

            this.nameTextBox.Text = "";

            nameNGButton.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            nameOKButton.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            inputCompleteButton.Visibility = Windows.UI.Xaml.Visibility.Visible;
        }

        private void inputCompleteButton_Click(object sender, RoutedEventArgs e)
        {
            var text = nameTextBox.Text;

            if (text != string.Empty)
            {
                this.announceText.Text = "あなたの名前は「" + text + "」でよろしいですか？\nよろしければ「これでいい」を、正しくない場合は「入力しなおす」を押してください。";

                this.name = text;

                nameNGButton.Visibility = Windows.UI.Xaml.Visibility.Visible;
                nameOKButton.Visibility = Windows.UI.Xaml.Visibility.Visible;
                inputCompleteButton.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            }
        }
    }
}
