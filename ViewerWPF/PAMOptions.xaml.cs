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
    public partial class PAMOptions : Window {

        public 画素ﾊﾝﾄﾞﾗー 画素 { get; }
        public ﾇﾌﾟーﾘﾊﾝﾄﾞﾗー ﾇﾌﾟーﾘ { get; }

        public bool ﾁｬﾝﾈﾙ選択 {
            get => RadioButtosGroup.IsEnabled;
            set => RadioButtosGroup.IsEnabled = value;
        }

        public PAMOptions() {
            InitializeComponent();
            画素 = new 画素ﾊﾝﾄﾞﾗー();
            ﾇﾌﾟーﾘ = new ﾇﾌﾟーﾘﾊﾝﾄﾞﾗー();
            FileFormatGroup.DataContext = ﾇﾌﾟーﾘ;
            ﾇﾌﾟーﾘ.PropertyChanged += 形式_PropertyChanged;

            ﾇﾌﾟーﾘ.Value = TonNurako.XImageFormat.PNM.ﾇﾌﾟーﾘ.RGB_ALPHA;
            RadioButtosGroup.IsEnabled = false;
            RadioButtosGroup.DataContext = 画素;
        }

        private void 形式_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e) {
            if (ﾇﾌﾟーﾘ.Value != TonNurako.XImageFormat.PNM.ﾇﾌﾟーﾘ.RGB_ALPHA &&
                ﾇﾌﾟーﾘ.Value != TonNurako.XImageFormat.PNM.ﾇﾌﾟーﾘ.RGB) {
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
