using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TonNurako.XImageFormat.Xi;

namespace XImageViewerWPF {

    public class Prop500 : System.ComponentModel.INotifyPropertyChanged {
        private ImageSource _img;
        public ImageSource Image {
            get { return _img; }
            set {
                _img = value;
                NotifyPropertyChanged();
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName]String propertyName = "") {
            if (PropertyChanged != null)
                PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }

    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {

        public string FileName { get; set; } = null;

        public Prop500 Image { get; }

        public MainWindow() {
            InitializeComponent();
            Extra.IsEnabled = false;
            Image = new Prop500();
            ImageVox.DataContext = Image;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            if (null != FileName) {
                LoadQ(FileName);
            }
        }

        private void Window_PreviewDragOver(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, true))
                e.Effects = DragDropEffects.Copy;
            else
                e.Effects = DragDropEffects.None;
            e.Handled = true;

        }

        public System.Collections.ObjectModel.ObservableCollection<項目> 項目ｽﾞ { get; set; }

        public class 項目 {
            public string 属性 { get; set; }
            public string 値 { get; set; }
        }

        private void Window_Drop(object sender, DragEventArgs e) {
            string[] files = e.Data.GetData(DataFormats.FileDrop) as string[];
            if (files == null) {
                return;
            }
            LoadQ(files[0]);
        }


        private ImageSource ToImageSource(TonNurako.XImageFormat.Xi.原色画像 xpm) {
            if (xpm.GetType() == typeof(ﾀﾞﾐー画像)) {
                return ((ﾀﾞﾐー画像)xpm).Source;
            }

            var bmp = new WriteableBitmap(xpm.Width, xpm.Height, 96, 96, PixelFormats.Bgra32, null);
            var o = xpm.Toぉ();
            var bgra = TonNurako.XImageFormat.Xi.おやさい.原色配列に変換(
                TonNurako.XImageFormat.Xi.ぉ.画素.B,
                TonNurako.XImageFormat.Xi.ぉ.画素.G,
                TonNurako.XImageFormat.Xi.ぉ.画素.R,
                TonNurako.XImageFormat.Xi.ぉ.画素.A,
                ref o);

            var rect = new Int32Rect(
                    0,
                    0,
                    xpm.Width,
                    xpm.Height);

            bmp.WritePixels(rect, bgra, bmp.PixelWidth * ((bmp.Format.BitsPerPixel + 7) / 8), 0);
            return bmp;
        }

        class ﾀﾞﾐー画像 : TonNurako.XImageFormat.Xi.原色画像 {

            public BitmapImage Source { get; }

            public ﾀﾞﾐー画像(BitmapImage im) {
                Source = im;
            }

            public string Name {
                get => "";
                set => throw new NotImplementedException(); }
            public int Width {
                get => Source.PixelWidth;
                set => throw new NotImplementedException(); }
            public int Height {
                get => Source.PixelHeight;
                set => throw new NotImplementedException(); }

            public ぉ[] Toぉ() {
                throw new NotImplementedException();
            }
        }

        private void LoadQ(string s) {
            TonNurako.XImageFormat.Xi.原色画像 原色画像 = null;
            try {
                if (s.EndsWith(".xpm", StringComparison.CurrentCultureIgnoreCase)) {
                    txtPath.Text = System.IO.Path.GetFileName(s);
                    var loader = new TonNurako.XImageFormat.XpmLoader();
                    原色画像 = loader.Load(s);
                    var im = ToImageSource(原色画像);
                    //ImageVox.Source = im;
                }
                else if (s.EndsWith(".xbm", StringComparison.CurrentCultureIgnoreCase)) {
                    txtPath.Text = System.IO.Path.GetFileName(s);
                    var loader = new TonNurako.XImageFormat.XbmLoader();
                    原色画像 = loader.Load(s);
                    var im = ToImageSource(原色画像);
                    //ImageVox.Source = im;
                }
                else if (s.EndsWith(".ppm", StringComparison.CurrentCultureIgnoreCase) ||
                    s.EndsWith(".pbm", StringComparison.CurrentCultureIgnoreCase) ||
                    s.EndsWith(".pgm", StringComparison.CurrentCultureIgnoreCase) ||
                    s.EndsWith(".pam", StringComparison.CurrentCultureIgnoreCase) ||
                    s.EndsWith(".pfm", StringComparison.CurrentCultureIgnoreCase)) {
                    txtPath.Text = System.IO.Path.GetFileName(s);
                    var loader = new TonNurako.XImageFormat.PNMLoader();
                    原色画像 = loader.Load(s);
                    var im = ToImageSource(原色画像);
                    //ImageVox.Source = im;
                }
                else {                   
                    var di = new ﾀﾞﾐー画像(new BitmapImage(new Uri(s)));
                    原色画像 = di;
                    //ImageVox.Source = di.Source;
                }
            }
            catch (TonNurako.XImageFormat.Xi.それちがう e) {
                MessageBox.Show($"{e.Message}\r\n{e.StackTrace}", "ｴﾗー", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            catch (TonNurako.XImageFormat.Xi.それ対応してない e) {
                MessageBox.Show($"{e.Message}\r\n{e.StackTrace}", "ｴﾗー", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Image.Image = ToImageSource(原色画像);


            this.FileName = s;
            Extra.IsEnabled = true;
            //ImageVox.Width = 原色画像.Width;
            //ImageVox.Height = 原色画像.Height;

            if (border1.ActualWidth < 原色画像.Width) {
                this.Width += (原色画像.Width - border1.ActualWidth);
            }

            if (border1.ActualHeight < 原色画像.Height) {
                this.Height += (原色画像.Height - border1.ActualHeight);
            }

            if (原色画像.GetType() != typeof(ﾀﾞﾐー画像)) {
                項目ｽﾞ = new System.Collections.ObjectModel.ObservableCollection<項目>();
                項目ｽﾞ.Add(
                    new 項目 {
                        属性 = "原色画像",
                        値 = 原色画像.GetType().ToString(),
                    }
                );

                var infoArray = 原色画像.GetType().GetProperties();

                foreach (var info in infoArray) {
                    if (info.PropertyType.IsArray ||
                        info.PropertyType.IsGenericType) {
                        continue;
                    }
                    var sv = "(NULL)";
                    var v = info.GetValue(原色画像, null);
                    if (null != v) {
                        sv = v.ToString();
                    }
                    項目ｽﾞ.Add(new 項目 { 属性 = info.Name, 値 = sv });
                }
            }
            else {
                項目ｽﾞ = new System.Collections.ObjectModel.ObservableCollection<項目>();
                項目ｽﾞ.Add(
                    new 項目 {
                        属性 = "原色画像",
                        値 = "システム標準",
                    }
                );  

            }
            this.listView.DataContext = 項目ｽﾞ;

        }

        private void ToggleButton_Loaded(object sender, RoutedEventArgs e) {
            var btn = (ToggleButton)sender;
            btn.SetBinding(ToggleButton.IsCheckedProperty, new Binding("IsOpen") { Source = btn.ContextMenu });
            btn.ContextMenu.PlacementTarget = btn;
            btn.ContextMenu.Placement = PlacementMode.Bottom;
        }

        delegate void SaveImageProc(string fileName);

        private async Task SaveImageAsync(string filter, string ext, SaveImageProc proc) {
            if (null == FileName) {
                return;
            }

            var dialog = new Microsoft.Win32.SaveFileDialog();
            dialog.Title = "保存";
            dialog.Filter = filter;
            dialog.FileName = System.IO.Path.GetFileNameWithoutExtension(FileName) + "." + ext;

            if (dialog.ShowDialog() == true) {
                Func<Task> testFunc = async () => {
                    proc(dialog.FileName);
                    await Task.Delay(100);
                };
                await testFunc();
            }
        }

        private TonNurako.XImageFormat.Xi.ぉ[] QonvertNA(BitmapSource bmp) {
            if (bmp.Format != PixelFormats.Bgra32) {
                bmp = new FormatConvertedBitmap(bmp, PixelFormats.Bgra32, null, 0);
            }

            int ppi = ((bmp.Format.BitsPerPixel + 7) / 8);
            int stride = bmp.PixelWidth * ppi;
            int size = bmp.PixelHeight * stride;
            byte[] pixels = new byte[size];
            bmp.CopyPixels(pixels, stride, 0);
            var conv = new TonNurako.XImageFormat.Xi.ぉ[bmp.PixelWidth * bmp.PixelHeight];
            int ro = 0;
            for (int i = 0; i < size; i += ppi) {
                conv[ro] = new TonNurako.XImageFormat.Xi.ぉ(
                    pixels[i + 2], pixels[i + 1], pixels[i], 0xff);
                ro++;
            }

            return conv;
        }

        private TonNurako.XImageFormat.Xi.ぉ[] QonvertA(BitmapSource bmp) {
            if (bmp.Format != PixelFormats.Bgra32) {
                bmp = new FormatConvertedBitmap(bmp, PixelFormats.Bgra32, null, 0);
            }

            int ppi = ((bmp.Format.BitsPerPixel + 7) / 8);
            int stride = bmp.PixelWidth * ppi;
            int size = bmp.PixelHeight * stride;
            byte[] pixels = new byte[size];
            bmp.CopyPixels(pixels, stride, 0);
            var conv = new TonNurako.XImageFormat.Xi.ぉ[bmp.PixelWidth * bmp.PixelHeight];
            int ro = 0;
            for (int i = 0; i < size; i += ppi) {
                conv[ro] = new TonNurako.XImageFormat.Xi.ぉ(
                    pixels[i + 2], pixels[i + 1], pixels[i], pixels[i + 3]);
                ro++;
            }

            return conv;
        }

        private async void SaveXPM_Click(object sender, RoutedEventArgs e) {
            await SaveImageAsync("XPM|*.xpm", "xpm", (fn) => 
            {
                var bm = (BitmapSource)ImageVox.Source;
                var xpm = TonNurako.XImageFormat.Xpm.Fromぉ(bm.PixelWidth, bm.PixelHeight, QonvertNA(bm));
                xpm.Name = System.IO.Path.GetFileNameWithoutExtension(fn);
                using (var s = new System.IO.FileStream(fn, System.IO.FileMode.Create)) {
                    (new TonNurako.XImageFormat.XpmWriter()).Write(s, xpm);
                }               
            });
        }

        private async void SaveXBM_Click(object sender, RoutedEventArgs e) {
            await SaveImageAsync("XBM|*.xbm", "xbm", (fn) => {

                var dialog = new XbmOptions();
                dialog.Owner = this;
                if (true != dialog.ShowDialog()) {
                    return;
                }
                var bm = (BitmapSource)ImageVox.Source;               
                var pfx = System.IO.Path.GetFileNameWithoutExtension(fn);
                using (var s = new System.IO.FileStream(fn, System.IO.FileMode.Create)) {
                    (new TonNurako.XImageFormat.XbmWriter()).Write(s,pfx, bm.PixelWidth, bm.PixelHeight, dialog.画素.Value, QonvertNA(bm));
                }
            });
        }

        private async void SavePPM_D_Click(object sender, RoutedEventArgs e) {
            if (null == FileName) {
                return;
            }
            var dialog = new PNMOptions();
            dialog.Owner = this;
            if (true != dialog.ShowDialog()) {
                return;
            }
            string filter = "";
            string ext = "";
            switch (dialog.形式.Value) {
                case TonNurako.XImageFormat.PNMWriter.ﾌｫーﾏｯﾂ.PBM:
                    filter = "PBM|*.pbm";
                    ext = "pbm";
                    break;
                case TonNurako.XImageFormat.PNMWriter.ﾌｫーﾏｯﾂ.PGM:
                    filter = "PGM|*.pgm";
                    ext = "pgm";
                    break;
                case TonNurako.XImageFormat.PNMWriter.ﾌｫーﾏｯﾂ.PPM:
                    filter = "PPM|*.ppm";
                    ext = "ppm";
                    break;
                case TonNurako.XImageFormat.PNMWriter.ﾌｫーﾏｯﾂ.PAM:
                    filter = "PAM|*.pam";
                    ext = "pam";
                    break;
            }
            await SaveImageAsync(filter, ext, (fn) => {
                var bm = (BitmapSource)ImageVox.Source;
                using (var s = new System.IO.FileStream(fn, System.IO.FileMode.Create)) {
                    (new TonNurako.XImageFormat.PNMWriter()).Write(
                        s, dialog.形式.Value, dialog.ｴﾝｺーﾃﾞｨﾝｸﾞ.Value, bm.PixelWidth, bm.PixelHeight, dialog.画素.Value, QonvertNA(bm));
                }

            });
        }

        private async void SavePAM_Click(object sender, RoutedEventArgs e) {
            var dialog = new PAMOptions();
            dialog.Owner = this;
            if (true != dialog.ShowDialog()) {
                return;
            }

            await SaveImageAsync("PAM|*.pam", "pam", (fn) => {
                var bm = (BitmapSource)ImageVox.Source;
                using (var s = new System.IO.FileStream(fn, System.IO.FileMode.Create)) {
                    (new TonNurako.XImageFormat.PNMWriter()).WritePAM(
                        s, dialog.ﾇﾌﾟーﾘ.Value, bm.PixelWidth, bm.PixelHeight, dialog.画素.Value, QonvertA(bm));
                }
            });
        }
    }
}
