using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace XImageViewerWPF {

    
    public class ﾇﾌﾟーﾘﾊﾝﾄﾞﾗー : System.ComponentModel.INotifyPropertyChanged {
        private TonNurako.XImageFormat.PNM.ﾇﾌﾟーﾘ _value;
        public TonNurako.XImageFormat.PNM.ﾇﾌﾟーﾘ Value {
            get { return _value; }
            set {
                if (_value == value)
                    return;

                if (!Enum.IsDefined(typeof(TonNurako.XImageFormat.PNM.ﾇﾌﾟーﾘ), value))
                    throw new ArgumentOutOfRangeException();

                _value = value;

                var handler = PropertyChanged;
                if (handler != null)
                    handler.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("Value"));
            }
        }
        #region INotifyPropertyChanged メンバー 
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        #endregion
    }

    [ValueConversion(typeof(TonNurako.XImageFormat.PNM.ﾇﾌﾟーﾘ), typeof(bool))]
    public class N2BConverter : System.Windows.Data.IValueConverter {
        private TonNurako.XImageFormat.PNM.ﾇﾌﾟーﾘ ConvertFromConverterParameter(object parameter) {
            string parameterString = parameter as string;
            return (TonNurako.XImageFormat.PNM.ﾇﾌﾟーﾘ)Enum.Parse(typeof(TonNurako.XImageFormat.PNM.ﾇﾌﾟーﾘ), parameterString);
        }

        #region IValueConverter メンバー
        public object Convert(object value, Type targetType, object parameter,
                              System.Globalization.CultureInfo culture) {
            var parameterValue = ConvertFromConverterParameter(parameter);
            return parameterValue.Equals(value);
        }
        public object ConvertBack(object value, Type targetType, object parameter,
                                  System.Globalization.CultureInfo culture) {
            if (!(bool)value)
                return System.Windows.DependencyProperty.UnsetValue;
            return ConvertFromConverterParameter(parameter);
        }
        #endregion
    }



    public class 形式ﾊﾝﾄﾞﾗー : System.ComponentModel.INotifyPropertyChanged {
        private TonNurako.XImageFormat.PNMWriter.ﾌｫーﾏｯﾂ _value;
        public TonNurako.XImageFormat.PNMWriter.ﾌｫーﾏｯﾂ Value {
            get { return _value; }
            set {
                if (_value == value)
                    return;

                if (!Enum.IsDefined(typeof(TonNurako.XImageFormat.PNMWriter.ﾌｫーﾏｯﾂ), value))
                    throw new ArgumentOutOfRangeException();

                _value = value;

                var handler = PropertyChanged;
                if (handler != null)
                    handler.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("Value"));
            }
        }
        #region INotifyPropertyChanged メンバー 
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        #endregion
    }

    [ValueConversion(typeof(TonNurako.XImageFormat.PNMWriter.ﾌｫーﾏｯﾂ), typeof(bool))]
    public class T2BConverter : System.Windows.Data.IValueConverter {
        private TonNurako.XImageFormat.PNMWriter.ﾌｫーﾏｯﾂ ConvertFromConverterParameter(object parameter) {
            string parameterString = parameter as string;
            return (TonNurako.XImageFormat.PNMWriter.ﾌｫーﾏｯﾂ)Enum.Parse(typeof(TonNurako.XImageFormat.PNMWriter.ﾌｫーﾏｯﾂ), parameterString);
        }

        #region IValueConverter メンバー
        public object Convert(object value, Type targetType, object parameter,
                              System.Globalization.CultureInfo culture) {
            var parameterValue = ConvertFromConverterParameter(parameter);
            return parameterValue.Equals(value);
        }
        public object ConvertBack(object value, Type targetType, object parameter,
                                  System.Globalization.CultureInfo culture) {
            if (!(bool)value)
                return System.Windows.DependencyProperty.UnsetValue;
            return ConvertFromConverterParameter(parameter);
        }
        #endregion
    }


    public class 画素ﾊﾝﾄﾞﾗー : System.ComponentModel.INotifyPropertyChanged {
        private TonNurako.XImageFormat.Xi.ぉ.画素 _value;
        public TonNurako.XImageFormat.Xi.ぉ.画素 Value {
            get { return _value; }
            set {
                if (_value == value)
                    return;

                if (!Enum.IsDefined(typeof(TonNurako.XImageFormat.Xi.ぉ.画素), value))
                    throw new ArgumentOutOfRangeException();

                _value = value;

                var handler = PropertyChanged;
                if (handler != null)
                    handler.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("Value"));
            }
        }
        #region INotifyPropertyChanged メンバー 
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        #endregion
    }

    public class ｴﾝｺーﾃﾞｨﾝｸﾞﾊﾝﾄﾞﾗー: System.ComponentModel.INotifyPropertyChanged {
        private TonNurako.XImageFormat.PNMWriter.ｴﾝｺーﾃﾞｨﾝｸﾞ _value;
        public TonNurako.XImageFormat.PNMWriter.ｴﾝｺーﾃﾞｨﾝｸﾞ Value {
            get { return _value; }
            set {
                if (_value == value)
                    return;

                if (!Enum.IsDefined(typeof(TonNurako.XImageFormat.PNMWriter.ｴﾝｺーﾃﾞｨﾝｸﾞ), value))
                    throw new ArgumentOutOfRangeException();

                _value = value;

                var handler = PropertyChanged;
                if (handler != null)
                    handler.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("Value"));
            }
        }
        #region INotifyPropertyChanged メンバー 
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        #endregion
    }

    [ValueConversion(typeof(TonNurako.XImageFormat.Xi.ぉ.画素), typeof(bool))]
    public class G2BConverter : System.Windows.Data.IValueConverter {
        private TonNurako.XImageFormat.Xi.ぉ.画素 ConvertFromConverterParameter(object parameter) {
            string parameterString = parameter as string;
            return (TonNurako.XImageFormat.Xi.ぉ.画素)Enum.Parse(typeof(TonNurako.XImageFormat.Xi.ぉ.画素), parameterString);
        }

        #region IValueConverter メンバー
        public object Convert(object value, Type targetType, object parameter,
                              System.Globalization.CultureInfo culture) {
            var parameterValue = ConvertFromConverterParameter(parameter);
            return parameterValue.Equals(value);
        }
        public object ConvertBack(object value, Type targetType, object parameter,
                                  System.Globalization.CultureInfo culture) {
            if (!(bool)value)
                return System.Windows.DependencyProperty.UnsetValue;
            return ConvertFromConverterParameter(parameter);
        }
        #endregion
    }

    [ValueConversion(typeof(TonNurako.XImageFormat.PNMWriter.ｴﾝｺーﾃﾞｨﾝｸﾞ), typeof(bool))]
    public class F2BConverter : System.Windows.Data.IValueConverter {
        private TonNurako.XImageFormat.PNMWriter.ｴﾝｺーﾃﾞｨﾝｸﾞ ConvertFromConverterParameter(object parameter) {
            string parameterString = parameter as string;
            return (TonNurako.XImageFormat.PNMWriter.ｴﾝｺーﾃﾞｨﾝｸﾞ)Enum.Parse(typeof(TonNurako.XImageFormat.PNMWriter.ｴﾝｺーﾃﾞｨﾝｸﾞ), parameterString);
        }

        #region IValueConverter メンバー
        public object Convert(object value, Type targetType, object parameter,
                              System.Globalization.CultureInfo culture) {
            var parameterValue = ConvertFromConverterParameter(parameter);
            return parameterValue.Equals(value);
        }
        public object ConvertBack(object value, Type targetType, object parameter,
                                  System.Globalization.CultureInfo culture) {
            if (!(bool)value)
                return System.Windows.DependencyProperty.UnsetValue;
            return ConvertFromConverterParameter(parameter);
        }
        #endregion
    }

}
