using Microsoft.VisualStudio.TestTools.UnitTesting;
using caiJiDll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caiJiDll.Tests
{
    [TestClass()]
    public class Class1Tests
    {
        [TestMethod()]
        public void convertHrefTest()
        {
            Class1.sURL = "https://www.sephora.cn/?rsour=sephoraUS&rmeth=test";
            string href= Class1.convertHref(@"/hot/t");
            Assert.AreEqual(href, @"https://www.sephora.cn/hot/t");
           
        }

        [TestMethod()]
        public void caiJiTest()
        {
            caiJiDll.Class1.sURL = "https://www.sephora.cn/?rsour=sephoraUS&rmeth=test";
            string s = "<a class=\"\" href=\"/hot\">";
            string sre = caiJiDll.Class1.caiJi(s);

            Assert.AreEqual(sre, "a\t href\t href path\n<a class=\"\" href=\"/hot\">\t/hot\thttps://www.sephora.cn/hot\n");
        }

        [TestMethod()]
        public void caiJiURLTest()
        {
            
            Class1.caiJiURL("https://www.sephora.cn/?rsour=sephoraUS&rmeth=test");
            
        }
    }
}