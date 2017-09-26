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
    public partial class XbmOptions : Window {

        public 画素ﾊﾝﾄﾞﾗー 画素 { get; }

        public XbmOptions() {
            InitializeComponent();
            画素 = new 画素ﾊﾝﾄﾞﾗー();
            RadioButtosGroup.DataContext = 画素;
        }

        private void Button_OK_Click(object sender, RoutedEventArgs e) {
            this.DialogResult = true;
        }

        private void Button_Cancel_Click(object sender, RoutedEventArgs e) {
            this.DialogResult = false;
        }

    }


}
