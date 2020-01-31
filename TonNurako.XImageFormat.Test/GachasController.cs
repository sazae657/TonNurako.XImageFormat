using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonNurako.XImageFormat.Test {
    public abstract class GachasController 
    {
        public string DataDir =>
            Path.GetFullPath(
                Path.Combine(
                    Path.GetDirectoryName(new Uri(this.GetType().Assembly.CodeBase).LocalPath), "../../../../ReaderTest/Data"));

        public string Gacha(string fn) {
            return Path.Combine(DataDir, fn);
        }

        public StreamReader Gachas(string fn) {
            return (new System.IO.StreamReader(Gacha(fn), System.Text.Encoding.UTF8));
        }


        public IEnumerable<string> Gachaes(string fn) {
            var lines = new List<string>();
            using (var file = Gachas(fn)) {
                string line = string.Empty;
                while ((line = file.ReadLine()) != null) {
                    lines.Add(line.Trim());
                }
            }
            return lines;
        }
    }
}
