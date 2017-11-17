using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TonNurako.XImageFormat.Test
{
    public class XbmTest : GachasController {

        [Fact]
        public void Load() {
            var loader = new XbmLoader();
            Assert.NotNull(loader.Load(Gacha("XBM.xbm")));
            

            using (var st = Gachas("XBM.xbm")) {
                Assert.NotNull(loader.Load("xbm", st.BaseStream));
            }

            Assert.NotNull(loader.Load("xbm", Gachaes("XBM.xbm")));
            

            Assert.Throws<Xi.それちがう>(() => loader.Load(Gacha("XPM.xpm")));
            Assert.Throws<Xi.それちがう>(() => loader.Load("xbm", Gachaes("XPM.xpm")));
            using (var st = Gachas("XPM.xpm")) {
                Assert.Throws<Xi.それちがう>(() => loader.Load("xbm", st.BaseStream));
            }
        }
    }
}
