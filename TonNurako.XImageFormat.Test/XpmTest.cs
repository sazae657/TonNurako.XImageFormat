using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TonNurako.XImageFormat.Test {
    public class XpmTest : GachasController {

        [Fact]
        public void Load() {
            var loader = new XpmLoader();
            Assert.NotNull(loader.Load(Gacha("XPM.xpm")));

            using (var st = Gachas("XPM.xpm")) {
                Assert.NotNull(loader.Load(st.BaseStream));
            }

            Assert.NotNull(loader.Load(Gachaes("XPM.xpm")));

            Assert.Throws<Xi.それちがう>(() => loader.Load(Gacha("XBM.xbm")));
            Assert.Throws<Xi.それちがう>(() => loader.Load(Gachaes("XBM.xbm")));
            using (var st = Gachas("XBM.xbm")) {
                Assert.Throws<Xi.それちがう>(() => loader.Load(st.BaseStream));
            }
        }
    }
}
