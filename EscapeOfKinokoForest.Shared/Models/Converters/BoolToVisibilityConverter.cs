using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace EscapeOfKinokoForest.Models.Converters
{
    class BoolToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// 逆を返すか？
        /// isReverseがtrueの場合入力値がtrueの場合にCollapsedを返す
        /// </summary>
        public bool isReverse { set; get; }

        public object Convert(object value, Type targetType, object parameter, string str)
        {
            if (isReverse)
            {
                return (Boolean)value == false ? Visibility.Visible : Visibility.Collapsed;
            }
            else
            {
                return (Boolean)value == true ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string str)
        {
            throw new NotImplementedException();
        }
    }
}
