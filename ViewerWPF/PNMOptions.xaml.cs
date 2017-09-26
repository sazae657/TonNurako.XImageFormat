using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace XImageViewerWPF {

    /// <summary>
    /// SaveOptions.xaml の相互作用ロジック
    /// </summary>
    public partial class PNMOptions : Window {

        public 画素ﾊﾝﾄﾞﾗー 画素 { get; }
        public ｴﾝｺーﾃﾞｨﾝｸﾞﾊﾝﾄﾞﾗー ｴﾝｺーﾃﾞｨﾝｸﾞ { get; }
        public 形式ﾊﾝﾄﾞﾗー 形式 { get; }

        public bool ﾁｬﾝﾈﾙ選択 {
            get => RadioButtosGroup.IsEnabled;
            set => RadioButtosGroup.IsEnabled = value;
        }

        public PNMOptions() {
            InitializeComponent();
            画素 = new 画素ﾊﾝﾄﾞﾗー();
            ｴﾝｺーﾃﾞｨﾝｸﾞ = new ｴﾝｺーﾃﾞｨﾝｸﾞﾊﾝﾄﾞﾗー();
            形式 = new 形式ﾊﾝﾄﾞﾗー();
            FileFormatGroup.DataContext = 形式;
            形式.PropertyChanged += 形式_PropertyChanged;

            形式.Value = TonNurako.XImageFormat.PNMWriter.ﾌｫーﾏｯﾂ.PPM;
            RadioButtosGroup.IsEnabled = false;
            RadioButtosGroup.DataContext = 画素;
            FormatGroup.DataContext = ｴﾝｺーﾃﾞｨﾝｸﾞ;

        }

        private void 形式_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e) {
            if (形式.Value != TonNurako.XImageFormat.PNMWriter.ﾌｫーﾏｯﾂ.PPM) {
                RadioButtosGroup.IsEnabled = true;
            }
            else {
                RadioButtosGroup.IsEnabled = false;
            }
        }

        private void Button_OK_Click(object sender, RoutedEventArgs e) {
            this.DialogResult = true;
        }

        private void Button_Cancel_Click(object sender, RoutedEventArgs e) {
            this.DialogResult = false;
        }

    }

}
