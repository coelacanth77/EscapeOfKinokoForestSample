using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace EscapeOfKinokoForest.Models
{
    class FlagData : INotifyPropertyChanged
    {
        public static bool is_item1_get = false; // アイテム1を取得したかどうか
        public static bool is_item2_get = false; // アイテム2を取得したかどうか
        public static bool is_item3_get = false; // アイテム3を取得したかどうか
        
        /// <summary>
        /// アイテム4（きのこのタッチ順を示す画像）を取得したかどうか
        /// </summary>
        public static bool is_item4_get = false;
        public static bool is_item5_get = false; // アイテム5を取得したかどうか
        
        /// <summary>
        /// アイテム6(四つ葉のクローバー)を取得したかどうか
        /// </summary>
        public static bool is_item6_get = false;
        public static bool is_item7_get = false; // 羊の情報をゲットしたかどうか

        public static int selected_image_num = 0;

        public static DateTime startTime = new DateTime();
        public static bool setStartTime = false;

        public static TimeSpan span = new TimeSpan();

        public static TranslateTransform transform;

        /// <summary>
        /// フラグを初期化する
        /// </summary>
        internal static void init()
        {
            FlagData.is_item1_get = false;
            FlagData.is_item2_get = false;
            FlagData.is_item3_get = false;
            FlagData.is_item4_get = false;
            FlagData.is_item5_get = false;
            FlagData.is_item6_get = false;
            FlagData.is_item7_get = false;
            FlagData.selected_image_num = 0;
            FlagData.setStartTime = false;
            FlagData.startTime = new DateTime();
            FlagData.span = new TimeSpan();
            FlagData.transform = null;
        }

        #region INotifyPropertyChangedの実装
        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] String propertyName = null)
        {
            if (object.Equals(storage, value)) return false;

            storage = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var eventHandler = this.PropertyChanged;
            if (eventHandler != null)
            {
                eventHandler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
