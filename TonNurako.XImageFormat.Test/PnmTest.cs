using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TonNurako.XImageFormat.Test {
    public class PnmTest : GachasController {

        [Theory]
        [InlineData("BAMb.pam")]
        [InlineData("PAMba.pam")]
        [InlineData("PAMg.pam")]
        [InlineData("PAMga.pam")]
        [InlineData("PAMrgb.pam")]
        [InlineData("PAMrgba.pam")]
        [InlineData("PBMb.pbm")]
        [InlineData("PBMt.pbm")]
        [InlineData("PGMb.pgm")]
        [InlineData("PGMt.pgm")]
        [InlineData("PPMb.ppm")]
        [InlineData("PPMt.ppm")]
        public void Load(string fn) {
            var loader = new PNMLoader();
            Assert.NotNull(loader.Load(Gacha(fn)));
            using (var st = Gachas(fn)) {
                Assert.NotNull(loader.Load(st.BaseStream));
            }
        }

        [Theory]
        [InlineData("XBM.xbm")]
        [InlineData("XPM.xpm")]
        public void LoadE(string fn) {
            var loader = new PNMLoader();
            Assert.Throws<Xi.それちがう>(()=>loader.Load(Gacha(fn)));
            using (var st = Gachas(fn)) {
                Assert.Throws<Xi.それちがう>(()=>loader.Load(st.BaseStream));
            }
        }
    }
}
