using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caiJi
{
    class Program
    {
        static void Main(string[] args)
        {
            caiJiDll.Class1.sURL = "https://www.sephora.cn/?rsour=sephoraUS&rmeth=test";
            string s = "<a class=\"\" href=\"/hot\">";
            string sre = caiJiDll.Class1.caiJi(s);
            if (args.Length > 0)
            {
                caiJiDll.Class1.caiJiURL(args[0]);
            }
            else
            {
                caiJiDll.Class1.caiJiURL("https://www.sephora.cn/?rsour=sephoraUS&rmeth=test");
            }
            
        }
     
    }
}
