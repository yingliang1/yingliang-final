using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace caiJiDll
{
    public class Class1
    {
        public static string convertHref(string xiangDuiLuJing)
        {
            if (xiangDuiLuJing.StartsWith(@"/"))
            {
                Regex reg = new Regex(@"^((http|https|)://.*?)/");
                Match m = reg.Match(sURL);
                if (m.Success == true)
                {
                    string s = m.Groups[1].Value + xiangDuiLuJing;
                    return s;
                }
            }
            return xiangDuiLuJing;
        }

        public static string caiJi(string s)
        {
            Regex reg = new Regex("<a[^<]*?>");
            MatchCollection mc = reg.Matches(s);
            string sre = "a\t href\t href path\n";
            if (mc.Count > 0)
            {
                foreach (Match m in mc)
                {
                    sre += m.Groups[0].Value + "\t";
                    Regex tmpreg = new Regex("href=\"(.*?)\"");
                    Match mt = tmpreg.Match(m.Groups[0].Value);
                    sre += mt.Groups[1].Value + "\t" + (mt.Success == true ? convertHref(mt.Groups[1].Value) : "") + "\n";
                }
            }
            return sre;
            
        }
        public static string sURL;
        public static void caiJiURL(string url)
        {
            sURL = url;
            string sre="";
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(sURL);
            req.Method = "GET";
            using (WebResponse wr = req.GetResponse())
            {
                string reader = new StreamReader(wr.GetResponseStream(), Encoding.GetEncoding("UTF-8")).ReadToEnd();
                sre=caiJi(reader);
                try
                {

                    System.IO.File.WriteAllText("sre.xls", sre);
                    //break;sebcrawlerp
                }
                catch (IOException e)
                {
                    Console.WriteLine("there is another file be used, please shut down.");

                }
                //}

                System.Diagnostics.Process.Start("sre.xls");
            }
            
            //while (true)
            //{
            

        }
       
    }
}
