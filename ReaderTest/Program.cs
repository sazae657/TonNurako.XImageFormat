using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaderTest {
    class Frogram {

        TonNurako.XImageFormat.XpmLoader xpm;
        TonNurako.XImageFormat.XbmLoader xbm;
        TonNurako.XImageFormat.PNMLoader pnm;

        public Frogram() {
            xpm = new TonNurako.XImageFormat.XpmLoader();
            xbm = new TonNurako.XImageFormat.XbmLoader();
            pnm = new TonNurako.XImageFormat.PNMLoader();
            Fail = new Dictionary<string, string>();
        }

        Dictionary<string, string> Fail { get; }

        void ReadAllImage(string dir) {
            foreach (string sub in Directory.GetDirectories(dir)) {
                try {
                    ReadAllImage(sub);
                }
                catch (System.UnauthorizedAccessException) {
                    Console.WriteLine($"permission denied:{sub}");
                }
            }

            foreach (string file in Directory.GetFiles(dir)) {
                TonNurako.XImageFormat.Xi.原色画像 img = null;
                try {
                    if (file.EndsWith(".xpm", StringComparison.CurrentCultureIgnoreCase)) {
                        img = xpm.Load(file);
                    }
                    else if (file.EndsWith(".xbm", StringComparison.CurrentCultureIgnoreCase)) {
                        img = xbm.Load(file);
                    }
                    else if (file.EndsWith(".pbm", StringComparison.CurrentCultureIgnoreCase) ||
                        file.EndsWith(".pgm", StringComparison.CurrentCultureIgnoreCase) ||
                        file.EndsWith(".ppm", StringComparison.CurrentCultureIgnoreCase) ||
                        file.EndsWith(".pnm", StringComparison.CurrentCultureIgnoreCase) ||
                        file.EndsWith(".pam", StringComparison.CurrentCultureIgnoreCase)) {
                        img = pnm.Load(file);
                    }
                }
                catch (TonNurako.XImageFormat.Xi.それちがう e) {
                    Console.WriteLine($"file:{file} : IGNORE <{e.Message}>");
                }
                catch (Exception e) {
                    Console.WriteLine($"file:{file} : FAIL <{e.Message}>");
                    Fail.Add(file, e.Message);
                }
                if (img != null) {
                    Console.WriteLine($"file:{file} : OK");
                }
            }
        }

        static void Main(string[] args) {
            if (args.Length == 0) {
                Console.Error.WriteLine("ﾁﾞﾚｸﾄﾘー指定が無い");
                return;
            }

            var f = new Frogram();
            f.ReadAllImage(args[0]);
            if (f.Fail.Count == 0) {
                return;
            }
            Console.WriteLine($"=== ｴﾗー {f.Fail.Count} 件 ===");
            foreach (var k in f.Fail.Keys) {
                Console.WriteLine($"{k} => {f.Fail[k]}");
            }
        }
    }
}
