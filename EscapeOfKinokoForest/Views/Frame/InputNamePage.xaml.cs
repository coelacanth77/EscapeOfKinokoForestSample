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
using Windows.UI.Input.Inking;


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
    public sealed partial class InputNamePage : Page
    {
        public MainFrame _parentPage { get; set; }

        private bool _isInput = true;

        private PointerPoint prevPoint;

        private uint pointerId;

        private InkManager inkManager = new InkManager();
        private string name = "";

        public InputNamePage()
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

        private void inkCanvas_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            if (this._isInput == false)
            {
                return;
            }

            var pt = e.GetCurrentPoint(this.inkCanvas);

            this.prevPoint = pt;

            if (pt.PointerDevice.PointerDeviceType == Windows.Devices.Input.PointerDeviceType.Pen ||
                pt.PointerDevice.PointerDeviceType == Windows.Devices.Input.PointerDeviceType.Touch ||
                pt.PointerDevice.PointerDeviceType == Windows.Devices.Input.PointerDeviceType.Mouse &&
                pt.Properties.IsLeftButtonPressed
                )
            {
                this.inkManager.ProcessPointerDown(pt);

                this.pointerId = pt.PointerId;

                e.Handled = true;
            }
        }

        private void inkCanvas_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            if (this._isInput == false)
            {
                return;
            }

            if (pointerId != e.Pointer.PointerId)
            {
                return;
            }

            var pt = e.GetCurrentPoint(inkCanvas);

            var line = new Line()
            {
                X1 = prevPoint.Position.X,
                Y1 = prevPoint.Position.Y,
                X2 = pt.Position.X,
                Y2 = pt.Position.Y,
                StrokeThickness = 2.0,
                Stroke = new SolidColorBrush(Colors.Green)
            };

            this.inkCanvas.Children.Add(line);

            this.inkManager.ProcessPointerUpdate(pt);
            this.prevPoint = pt;

            e.Handled = true;
        }

        private void inkCanvas_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            if (this._isInput == false)
            {
                return;
            }

            if (e.Pointer.PointerId != this.pointerId)
            {
                return;
            }

            var pt = e.GetCurrentPoint(inkCanvas);

            this.inkManager.ProcessPointerUp(pt);

            this.pointerId = 0;
        }

        private async void inputCompleteButton_Click(object sender, RoutedEventArgs e)
        {
            var recogniser = this.inkManager.GetRecognizers().FirstOrDefault(r => r.Name.IndexOf("日本語") != -1);

            if (recogniser != null)
            {
                this.inkManager.SetDefaultRecognizer(recogniser);

                try
                {
                    var recogs = await inkManager.RecognizeAsync(InkRecognitionTarget.All);

                    var text = string.Concat(recogs.Select(r => r.GetTextCandidates().First()));

                    if (text == "")
                    {
                        this.announceText.Text = "タッチ操作またはマウスで下のエリアに文字を書いて名前を入力してください（9文字まで）\n入力後は「入力おわり」を押してください。";

                        return;
                    }

                    this.announceText.Text = "あなたの名前は「" + text + "」でよろしいですか？\nよろしければ「これでいい」を、正しくない場合は「入力しなおす」を押してください。";

                    this._isInput = false;

                    this.name = text;

                    nameNGButton.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    nameOKButton.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    inputCompleteButton.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                }
                catch (ArgumentException)
                {
                }
                catch (Exception)
                {
                    this.announceText.Text = "タッチ操作またはマウスで下のエリアに文字を書いて名前を入力してください（9文字まで）\n入力後は「入力おわり」を押してください。";
                }
            }
            else
            {
                this.announceText.Text = "日本語の解析ライブラリが見つかりませんでした。日本語版のWindows 8でのみ利用可能です。";
                this.inputCompleteButton.IsEnabled = false;
            }
        }

        private void nameOKButton_Click(object sender, RoutedEventArgs e)
        {
            UserData.name = this.name;

            this._parentPage.endNameInput();
        }

        private void nameNGButton_Click(object sender, RoutedEventArgs e)
        {
            this.announceText.Text = "タッチ操作またはマウスで下のエリアに文字を書いて名前を入力してください（9文字まで）\n入力後は「入力おわり」を押してください。";

            this._isInput = true;

            foreach (var stroke in this.inkManager.GetStrokes())
            {
                stroke.Selected = true;
            }

            this.inkManager.DeleteSelected();

            this.inkCanvas.Children.Clear();

            nameNGButton.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            nameOKButton.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            inputCompleteButton.Visibility = Windows.UI.Xaml.Visibility.Visible;
        }
    }
}
